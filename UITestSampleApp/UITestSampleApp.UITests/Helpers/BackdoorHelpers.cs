﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace UITestSampleApp.UITests
{
	static class BackdoorHelpers
	{
		internal static void CleariOSKeyChain(IApp app, string username)
		{
			if (app is iOSApp)
				app.Invoke("clearKeyChain:", username);
		}

		internal static void SetiOSXTCAgent(IApp app)
		{
			if (app is iOSApp)
				app.Invoke("xtcAgent:", "");
		}

		internal static void BypassLoginScreen(IApp app)
		{
			if (app is iOSApp)
				app.Invoke("bypassLoginScreen:", "");
			else
				app.Invoke("BypassLoginScreen");

			app.Screenshot("Backdoor Bypass Login Screen");
		}

		internal static void OpenListViewPage(IApp app)
		{
			if (app is iOSApp)
				app.Invoke("openListViewPage:", "");
			else
				app.Invoke("OpenListViewPage");

			app.Screenshot("Backdoor to List View Page");
		}

		internal static List<ListPageDataModel> GetListPageData(IApp app)
		{
			string listPageDataAsBase64String;

			if (app is iOSApp)
				listPageDataAsBase64String = app.Invoke("getListViewPageDataAsBase64String:", "").ToString();
			else
				listPageDataAsBase64String = app.Invoke("GetListViewPageDataAsBase64String").ToString();

			return ConverterHelpers.ConvertBase64StringToObject<List<ListPageDataModel>>(listPageDataAsBase64String);
		}
	}
}
