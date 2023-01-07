﻿using System;
using System.IO;
using Tommy;

namespace UncannyRPC.Helpers;

public class TomlParser
{
    private TomlTable Table;
    
    public readonly PresenceObject Data = new();

    public TomlParser(StreamReader? filePath)
    {
        try
        {
            Table = TOML.Parse(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine();
            throw;
        }
        PopulateData();
    }

    private void PopulateData()
    {
        try
        {
            Data.Title = Table["title"] ?? "uncanny_rpc_config";
            Data.CoverImage = Table["general"]["coverimage_url"] ?? "default";
            Data.UpdateInterval = Table["general"]["update_interval"] ?? 1000;
            Data.IsCpuEnabled = Table["cpu_monitor"]["enabled"] ?? true;
            Data.CpuTitle = Table["cpu_monitor"]["title"] ?? "CPU";
            Data.CpuSeperator = Table["cpu_monitor"]["seperator"] ?? "-";
            Data.CpuCurrentRound = Table["cpu_monitor"]["percent_roundoff"] ?? 2;
            Data.RamTitle = Table["memory_monitor"]["title"] ?? "RAM";
            Data.IsRamEnabled = Table["memory_monitor"]["enabled"] ?? true;
            Data.RamSeperator = Table["memory_monitor"]["seperator"] ?? "-";
            Data.RamCurrentRound = Table["memory_monitor"]["current_roundoff"] ?? 2;
            Data.RamTotalRound = Table["memory_monitor"]["total_roundoff"] ?? 2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}

public class PresenceObject
{
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public int UpdateInterval { get; set; }
    public bool IsCpuEnabled { get; set; }
    public bool IsRamEnabled { get; set; }
    public string? CpuTitle { get; set; }
    public string? RamTitle { get; set; }
    public string? ImageSource { get; set; }
    public string? CpuSeperator { get; set; }
    public string? RamSeperator { get; set; }
    public int CpuCurrentRound { get; set; }
    public int RamCurrentRound { get; set; }
    public int RamTotalRound { get; set; }
}