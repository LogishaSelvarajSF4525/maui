using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.ScrollView)]

public class ScrollView_DynamicGridWithChildrenFeatureTests : UITest
{

	public const string ScrollViewWithLayoutOptionsFeatureMatrix = "ScrollView With LayoutOptions Feature Matrix";
	public ScrollView_DynamicGridWithChildrenFeatureTests(TestDevice device)
		: base(device)
	{
	}

	protected override void FixtureSetup()
	{
		base.FixtureSetup();
		App.NavigateToGallery(ScrollViewWithLayoutOptionsFeatureMatrix);
	}

	[Test, Order(1)]
	public void VerifyGridWithAddChildren()
	{
		App.WaitForElement("DynamicGridLayoutButton");
		App.Tap("DynamicGridLayoutButton");
		App.WaitForElement("ScrollViewWithDynamicGridLayout");
		App.WaitForElement("AddButton");
		App.Tap("AddButton");
		App.WaitForElement("Label 4");
	}

	[Test, Order(2)]
	public void VerifyGridWithRemoveChildren()
	{
		App.WaitForElement("ScrollViewWithDynamicGridLayout");
		App.WaitForElement("RemoveButton");
		App.Tap("RemoveButton");
		App.WaitForNoElement("Label 4");
	}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS //related issue link:https://github.com/dotnet/maui/issues/32221
	[Test, Order(3)]
	public void VerifyGridWithResizesCorrectly_AfterAddingAndRemovingChildren()
	{
		App.WaitForElement("ScrollViewWithDynamicGridLayout");
		App.WaitForElement("AddButton");

		for (int i = 0; i < 6; i++)
		{
			App.Tap("AddButton");
		}

		App.WaitForElement("RemoveButton");

		for (int i = 0; i < 5; i++)
		{
			App.Tap("RemoveButton");
		}
		VerifyScreenshot();
	}
#endif
}