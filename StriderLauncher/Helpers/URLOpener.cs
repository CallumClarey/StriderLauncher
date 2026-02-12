using System;
using System.Diagnostics;

namespace StriderLauncher.Helpers;

public static class UrlOpener
{
    //static members used for handling if there has been an error opening a url
    public static bool HadUrlError { get; private set; } = false;
    //this will be displayed to the UI later 
    public static string ErrorMessage { get; private set; } = string.Empty;
    
    /// <summary>
    /// Takes the Url as an input then returns either true if opened false if not
    /// </summary>
    /// <param name="urlTarget"></param>
    /// <returns></returns>
    public static void OpenUrl(string urlTarget)
    {
        //validate before process start 
        if(!ValidateUrlTarget(urlTarget)) return;        
        
        try
        {
            Process.Start("explorer", urlTarget);
            HadUrlError = false;
        }
        catch (Exception e)
        {
            HadUrlError = true;
            ErrorMessage = e.Message; //pass the message to the error message
        }
    }

    /// <summary>
    /// Function will validate the url incoming
    /// </summary>
    /// <param name="urlTarget"></param>
    /// <returns></returns>
    private static bool ValidateUrlTarget(string urlTarget)
    {
        //handles null checks 
        if (string.IsNullOrWhiteSpace(urlTarget))
        {
            ErrorMessage = "URL Target is required, Url is empty or null.";
            HadUrlError = true;
            return false;
        }

        //handles validation
        if (!(urlTarget.StartsWith("http://") || urlTarget.StartsWith("https://")))
        {
            ErrorMessage = "URL Target is not a valid URL.";
            HadUrlError = true;
            return false;
        }
        
        HadUrlError = false;
        return true;
    }
}