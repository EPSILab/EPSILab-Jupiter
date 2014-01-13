using System;
using System.Web;

namespace SolarSystem.Jupiter
{
    /// <summary>
    /// IIS global actions
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Raised when the application starts
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        void Application_Start(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Raised when the application stops
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        void Application_End(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Raised when an unmanaged error occured
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        void Application_Error(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Raised when a session starts
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        void Session_Start(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Raised when a session stops
        /// </summary>
        /// <remarks>
        /// Session_End is raised only if SessionState mode has InProc value in the web.config file.
        /// If session mode is StateServer or SQLServer, the event is not raised.
        /// </remarks>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        void Session_End(object sender, EventArgs e)
        {
            
        }
    }
}