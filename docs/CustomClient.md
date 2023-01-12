<div align="center">

# Adding your Custom RPC Client

The instructions in this part will show you how
to develop your own Discord application so that
it uses your app name rather than "UncannyRPC"
to identify itself.

</div>


### 1. Go to Discord Developer Portal

To get started, you want to create an application
first. To do that, head over to [Discord Developer
Portal](https://discord.com/developers/applications). 

You'll see the portal website screen as shown 
below after logging in using your Discord 
account.

![](https://i.imgur.com/xnIzNDT.png)

### 2. Click on "New Application"

Click on the "New Application" button that appears
at the top-right corner of the webpage.

![](https://i.imgur.com/9TVfTrj.png)

### 3. Give a nice Name to your app

Now, type in a good name for your app. Note that
the name you type in __will appear on 
your discord profile__. After checking the check
mark, click on "Create".

![](https://i.imgur.com/AygPMJN.png)

### 4. Copy the Application ID of your app

After the above step, you'll be redirected to the
app dashboard. There you'll find the "APPLICATION
ID" of the app. Click on the "Copy" button.

![](https://i.imgur.com/I3Q9rtT.png)

### 5. Replace the UncannyRPC's app id with your's

Go to the UncannyRPC app and Click on "Edit Config File".
Now, replace the `app_id` property with your copied APP ID.

![](https://i.imgur.com/YmY5Ilp.png)

Click on "Save" and restart your app.

### 6. Your custom app with custom name is ready...!

Now, start the RPC and you can see the name of 
the App has changed in your discord profile's RPC.

![](https://i.imgur.com/e4Th0dk.png)