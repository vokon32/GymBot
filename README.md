Gym bot  
Description  
Telegram bot for managing your daily training.  
  
About the project  
The Gym bot is built on Asp Net Core using the Telegram.Bot library. The bot uses SQLite and EF Core to save data. The bot uses webhooks to get updates.  
  
Setup  
This is an short description how you can test the bot locally.  
  
Replace token  
At first you have to set your own token and url for webhook (development only) in AppSetting.json  
"Token": {Your Token},  
"Url": {Your url}"  

Ngrok  
Ngrok gives you the opportunity to access your local machine from a temporary subdomain provided by ngrok. This domain can later send to the telegram API as URL for the webhook. Install ngrock from this page Ngrok and run command  
  
ngrok http 8443   
From ngrok you get an URL to your local server. Set the url in AppSetting.json and the webhook will set automatically when the bot starts.  
