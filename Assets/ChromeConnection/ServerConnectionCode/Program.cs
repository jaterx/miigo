//namespace Unosquare
//{
using System;
using System.Threading;
using System.Diagnostics;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class Program : MonoBehaviour
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    
    public static int miigoInt = -2;
    public static int miigoChoiceInt = -999;
    public static int miigoCorrectChoiceInt = -999;

    public static int port = 8877;

    private static IPAddress ipAddress;

    public static int ledInt = -2;

    void Start()
    {
        //string[] args = Environment.GetCommandLineArgs();

        /*
        foreach (string s in args) {
            UnityEngine.Debug.Log(s); 
        }*/

        //if (args != null) {
        //ProcessArguements();
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            ProcessArguements();
        }).Start();
    }

    public static void ProcessArguements()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        //do what you want with the IP here... add it to a list, just get the first and break out. Whatever.
                        //UnityEngine.Debug.Log(ip.Address.ToString());
                        ipAddress = ip.Address;
                    }
                }
            }
        }

        var url = "http://" + ipAddress.ToString() + ":" + port.ToString();
        UnityEngine.Debug.Log(url);
        //var url = "http://0.0.0.0:8877";
        /*if (args.Length > 0)
            url = args[0];*/
        
        //UnityEngine.Debug.Log("It's working!");
        var webOptions = new WebServerOptions(url) { Mode = HttpListenerMode.EmbedIO };
        // Our web server is disposable.

        using (var server = new WebServer(webOptions))
        {
            // First, we will configure our web server by adding Modules.
            // Please note that order DOES matter.
            // ================================================================================================
            // If we want to enable sessions, we simply register the LocalSessionModule
            // Beware that this is an in-memory session storage mechanism so, avoid storing very large objects.
            // You can use the server.GetSession() method to get the SessionInfo object and manupulate it.
            // You could potentially implement a distributed session module using something like Redis
            //server.WithLocalSession();

            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<ActionController> ();

            // Here we setup serving of static files
            //server.RegisterModule(new StaticFilesModule("c:/web"));
            // The static files module will cache small files in ram until it detects they have been modified.
            //server.Module<StaticFilesModule>().UseRamCache = true;

            // Once we've registered our modules and configured them, we call the RunAsync() method.

            server.RunAsync();
            //UnityEngine.Debug.Log("It's a good sign.");
              
            // Fire up the browser to show the content if we are debugging!
            var browser = new System.Diagnostics.Process()
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
            };
            //browser.Start();

            // Wait for any key to be pressed before disposing of our web server.
            // In a service, we'd manage the lifecycle of our web server using
            // something like a BackgroundWorker or a ManualResetEvent.

            //Console.ReadKey(true);

            System.Threading.Thread.Sleep(Timeout.Infinite);

        }
    }

    /*
    void Update()
    {
        server.RunAsync();
    }
    */
}