
privete WindowsDriver<WindosElement> driver;
public WindowsDriver<WindosElement> CreateDesktopWindowSessionAtRootLevel()
{
	AppiumOptions appSessionObj = new AppiumOptions();
    appSessionObj.AddAdditionalCapability(“app”,”Root”);
    appSessionObj.AddAdditionalCapability(“deviceName”,”WindowPC);
    driver = new WindowsDriver<WindosElement>(new Uri(AppiumDriverURL),appSessionObj); //AppiumDriverURL - eneter the URL
    driver.Manager().Timeouts().ImplicitWait = TimeSpan.ForSeconds(30);
    return driver;	
}


privete WindowsDriver<WindosElement> driver;
//apptext = app process name or app titile to seach the running process
public WindowsDriver<WindosElement> CreateDesktopWindowSessionAtRootLevel(string appText = "Client")
{
    try
    {
        IntPtr appTopLelevWindowHandle = new IntPtr();
        foreach(Process processObj in Process.GetProcess())
        {
            if( processObj.ProcessName.IndexOf(aptText, StringComparison.OrdinalIgnoreCase) >= 0  ||
                 processObj.MainWindowTitle.IndexOf(appText, StringComparison.OrdinalIgnoreCase) >= 0)
                 {
                    appTopLelevWindowHandle = processObj.MainWindowHandler;
                    if(appTopLelevWindowHandle.ToString().Equals("0"))
                    {
                        continue;
                    }
                    break;
                 }
                var appTopLelevWindowHandleHexString = appTopLelevWindowHandle.ToString("x"); //convert number to Hex string
                AppiumOptions appSessionObj = new AppiumOptions();
                appSessionObj.AddAdditionalCapability("appTopLevelWindow", appTopLelevWindowHandleHexString);
                appSessionObj.AddAdditionalCapability("deviceName", "WindowPC");
                driver = new WindowsDriver<WindosElement>(new Uri(AppiumDriverURL),appSessionObj); //AppiumDriverURL - eneter the URL
                driver.Manager().Timeouts().ImplicitWait = TimeSpan.ForSeconds(30);
                return driver;
        }
        catch(System.Exception ex)
        {
            Console.WriteLine("Unable to create session at appTopLevelWindow. Error message :" + ex.Message);
            throw;
        }
        return driver           
    }
}


privete WindowsDriver<WindosElement> driver;
//applicationPath = path of the application
public WindowsDriver<WindosElement> CreateApplicationLevelSession(string applicationPath)
{

    AppiumOptions appSessionObj = new AppiumOptions();
    try
    {                
        appSessionObj.AddAdditionalCapability("app", applicationPath);
        appSessionObj.AddAdditionalCapability("deviceName", "WindowPC");
        driver = new WindowsDriver<WindosElement>(new Uri(AppiumDriverURL),appSessionObj); //AppiumDriverURL - eneter the URL
        driver.Manager().Timeouts().ImplicitWait = TimeSpan.ForSeconds(30);    //30 - time came be changed as per project requirement
        catch(System.Exception ex)
        {
            Console.WriteLine("Error while initializing window session. Error message :" + ex.Message);
            throw;
        }
        return driver           
    }
}
