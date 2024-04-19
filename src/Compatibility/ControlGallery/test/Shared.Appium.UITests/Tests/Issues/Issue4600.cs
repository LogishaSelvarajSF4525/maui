﻿using NUnit.Framework;
using UITest.Appium;

namespace UITests
{
	public class Issue4600 : IssuesUITest
	{
		public Issue4600(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[iOS] CollectionView crash with empty ObservableCollection";
		public override bool ResetMainPage => false;

		[Test]
		[Category(UITestCategories.CollectionView)]
		[FailsOnIOS]
		public void InitiallyEmptySourceDisplaysAddedItem()
		{
			this.IgnoreIfPlatforms([TestDevice.Android, TestDevice.Mac, TestDevice.Windows]);

			RunningApp.WaitForNoElement("Insert");
			RunningApp.Tap("btnInsert");
			RunningApp.WaitForNoElement("Inserted");
		}
	}
}