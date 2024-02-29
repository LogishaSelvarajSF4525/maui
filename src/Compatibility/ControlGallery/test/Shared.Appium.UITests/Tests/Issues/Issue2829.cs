﻿using NUnit.Framework;
using UITest.Appium;

namespace UITests
{
	public class Issue2829 : IssuesUITest
	{
		const string kScrollMe = "kScrollMe";
		const string kSuccess = "SUCCESS";
		const string kCreateListViewButton = "kCreateListViewButton";

		public Issue2829(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[Android] Renderers associated with ListView cells are occasionaly not being disposed of which causes left over events to propagate to disposed views";

		[Test]
		public void ViewCellsAllDisposed()
		{
			this.IgnoreIfPlatforms([TestDevice.iOS, TestDevice.Mac, TestDevice.Windows]);

			App.Click(kCreateListViewButton);
			App.WaitForNoElement("0");
			App.Click(kScrollMe);
			App.WaitForNoElement("70");
			App.Back();
			App.WaitForElement(kSuccess);
		}
	}
}