<div align="center">

# The TOML Configuration Documentation

</div>

# 

The RPC Displayed in your profile can have a
multitude of features and qualities changed 
using the UncannyRPC's extensive 
customization options.

## The TOML file
The UncannyRPC's configuration file is written in TOML.
Why, then, TOML? The reason is that de-serializing 
necessary properties from a configuration file 
using TOML is the fastest and most effective method
available.

## The Default Configuration
An example of a configuration file is shown below, 
and this is the default configuration that comes 
with the app by default.

```toml
# This title should be required to appear.
title = "uncanny_rpc_config"

# General properties
[general]
app_id = 1061295120948932789
coverimage_url = "default"
update_interval = 10000

# CPU usage display properties
[cpu_monitor]
title = "CPU"
enabled = true
seperator = "-"
percent_roundoff = 2

# Memory(RAM) usage display properties
[memory_monitor]
title = "RAM"
enabled = true
seperator = "-"
current_roundoff = 2
total_roundoff = 2
```

> #### Note:
> In the event that you incorrectly configured 
> your app, you can use the above configuration 
> to replace it.

## Diving into the Config Properties

This section contains information on all of 
the app's configuration properties.


## 1. `title` property

This property doesn't make any changes to the app.
this is optional.

## 2. `[General]` section

### 2.1 `app_id` property
To display your own app name in your Rich 
Presence, replace the app id with your own 
Discord app id. To learn how to make your own 
app, go [here](https://i.imgur.com/SMd8gDb.png).

### 2.2 `coverimage_url` property
This characteristic matches the Rich presence's
image. The altering "Mr. Incredible 
becoming Uncanny" image will show up when it is in 
`default`. When a custom URL is provided, 
the rich presence shows the supplied picture 
in the URL. Sets itself to `default`.

Usage,
```toml
# default setting
coverimage_url = "default"

# custom url
coverimage_url = "https://apicms.thestar.com.my/uploads/images/2021/12/28/1423090.jpg" # or anything you want
```
### 2.3 `update_interval` property

`update_interval` is used to set the update time 
of the Rich Presence in `ms`. Defaults to `10000`ms.

Usage,
```toml
# default setting
update_interval = 10000

# custom setting
update_interval = 15000 # or anything you want
```

> #### Note:
> The best setting for `update_interval`
> is between `10000` to `60000` Don't go beyond or
> less than this value.

## 3. `[cpu_monitor]` section

### 3.1 `title` property

The `title` property is used to set the title of
the CPU monitor shown in the Rich Presence.

![](https://i.imgur.com/MdODbe8.png)

Usage,
```toml
# default setting
title = "CPU"

# custom setting
title = "Processor" # or anything you want
```

### 3.2 `enabled` property

The `enable` property sets the visibility of the
CPU monitor to either Visible or Hidden.

Usage,
```toml
# default setting
enabled = true

# custom setting
enabled = false
```

### 3.3 `seperator` property

The `seperator` property is used to set the separating
character between the title and the actual reading
of the CPU Monitor.

![](https://i.imgur.com/Avyg2Ci.png)

Usage,
```toml
# default setting
seperator = "-"

# custom setting
seperator = "->" # or anything you want
```

### 3.4 `percent_roundoff` property

The `percent_roundoff` property is used to set the 
total number of digits to be present after the 
decimal point of the CPU percentage value.

![](https://i.imgur.com/qTvzf3G.png)

In the above image, the value rounds off to two numbers
after the decimal point when `percent_roundoff` is
set to 2.

Usage,
```toml
# default setting
percent_roundoff = 2

# custom setting
percent_roundoff = 4 # or anything you want
```

> #### Note:
> The value of `percent_roundoff` should not exceed 5.

## 4. `[memory_monitor]` section

### 4.1 `title` property

The `title` property is used to set the title of
the Memory monitor shown in the Rich Presence.

![](https://i.imgur.com/skNEkEf.png)

Usage,
```toml
# default setting
title = "RAM"

# custom setting
title = "Memory" # or anything you want
```

### 4.2 `enabled` property

The `enable` property sets the visibility of the
Memory monitor to either Visible or Hidden.

Usage,
```toml
# default setting
enabled = true

# custom setting
enabled = false
```

### 4.3 `seperator` property

The `seperator` property is used to set the separating
character between the `title` and the actual reading
of the Memory Monitor.

![](https://i.imgur.com/9kEU1oH.png)

Usage,
```toml
# default setting
seperator = "-"

# custom setting
seperator = "->" # or anything you want
```

### 4.4 `current_roundoff` property

The `current_roundoff` property is used to set the
total number of digits to be present after the
decimal point of the Current Memory usage value.

![](https://i.imgur.com/am1aORJ.png)

In the above image, the value rounds off to two numbers
after the decimal point when `current_roundoff` is
set to 2.

Usage,
```toml
# default setting
current_roundoff = 2

# custom setting
current_roundoff = 4 # or anything you want
```

> #### Note:
> The value of `current_roundoff` should not exceed 5.


### 4.5 `total_roundoff` property

The `total_roundoff` property is used to set the
total number of digits to be present after the
decimal point of the Total Memory value.

![](https://i.imgur.com/JHC0IBi.png)

In the above image, the value rounds off to two numbers
after the decimal point when `total_roundoff` is
set to 2.

Usage,
```toml
# default setting
total_roundoff = 2

# custom setting
total_roundoff = 4 # or anything you want
```

> #### Note:
> The value of `total_roundoff` should not exceed 5.