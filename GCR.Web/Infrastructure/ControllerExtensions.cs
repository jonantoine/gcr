﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCR.Core;
using GCR.Web.Models;
using Newtonsoft.Json;

namespace GCR.Web.Infrastructure
{
    public static class ControllerExtensions
    {
        public static void ShowMessageAfterRedirect(this Controller controller, MessageMode status, string message)
        {
            ShowMessageAfterRedirect(controller, new StatusMessage(status, message));
        }

        public static void ShowMessageAfterRedirect(this Controller controller, StatusMessage message)
        {
            controller.TempData["StatusMessage"] = JsonConvert.SerializeObject(message);
        }

        public static void LogError(this Controller controller, Exception ex)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        }

        public static bool IsAjaxRequest(this Controller controller)
        {
            string value = controller.Request.Headers["X-Requested-With"];
            if (value == "XMLHttpRequest")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}