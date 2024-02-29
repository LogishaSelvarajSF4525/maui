﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace UITests
{
	public class Issue1905 : IssuesUITest
	{
		public Issue1905(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "AlertView doesn't scroll when text is to large"; 
		
		[Test]
		public void TestIssue1905RefreshShows()
		{
			this.IgnoreIfPlatforms([TestDevice.iOS, TestDevice.Mac, TestDevice.Windows]);

			// wait for test to load
			App.WaitForElement("btnRefresh");
			App.Screenshot("Should show refresh control");

			// wait for test to finish so it doesn't keep working
			// in the background and break the next test
			App.WaitForElement("data refreshed");
		}
	}
}