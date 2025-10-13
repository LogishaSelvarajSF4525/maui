using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.Layout)]
public class BindableLayoutFeatureTests : UITest
{
	public const string BindableLayoutFeatureMatrix = "BindableLayout Feature Matrix";

	public BindableLayoutFeatureTests(TestDevice device)
		: base(device)
	{
	}

	protected override void FixtureSetup()
	{
		base.FixtureSetup();
		App.NavigateToGallery(BindableLayoutFeatureMatrix);
	}

	[Test]
	public void VerifyBindableLayoutWithItemsSourceNone()
	{
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceNone");
		App.Tap("ItemsSourceNone");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		VerifyScreenshot();
	}

	[Test]
	public void VerifyBindableLayoutWithItemsSourceObservableCollection()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		VerifyScreenshot();
	}

	[Test]
	public void VerifyBindableLayoutWithItemsSourceEmptyCollection()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceEmptyCollection");
		App.Tap("ItemsSourceEmptyCollection");
		App.WaitForElement("EmptyViewString");
		App.Tap("EmptyViewString");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("No Items Available(String)");
	}

	[Test]
	public void VerifyBindableLayoutWithEmptyViewString()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceEmptyCollection");
		App.Tap("ItemsSourceEmptyCollection");
		App.WaitForElement("EmptyViewString");
		App.Tap("EmptyViewString");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("No Items Available(String)");
	}

	[Test]
	public void VerifyBindableLayoutWithEmptyViewView()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceEmptyCollection");
		App.Tap("ItemsSourceEmptyCollection");
		App.WaitForElement("EmptyViewGrid");
		App.Tap("EmptyViewGrid");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("No Items Available(Grid View)");
	}

	[Test]
	public void VerifyBindableLayoutWithEmptyViewTemplate()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("EmptyViewTemplateGrid");
		App.Tap("EmptyViewTemplateGrid");
		App.WaitForElement("ItemsSourceEmptyCollection");
		App.Tap("ItemsSourceEmptyCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("No Template Items Available(Grid View)");
	}

	[Test]
	public void VerifyBindableLayoutWithBasicItemTemplate()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("ItemTemplateBasic");
		App.Tap("ItemTemplateBasic");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		VerifyScreenshot();
	}

	[Test]
	public void VerifyBindableLayoutWithGridItemTemplate()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("ItemTemplateGrid");
		App.Tap("ItemTemplateGrid");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		VerifyScreenshot();
	}

	[Test]
	public void VerifyBindableLayoutWithItemTemplateSelector()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("ItemTemplateSelectorAlternate");
		App.Tap("ItemTemplateSelectorAlternate");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		VerifyScreenshot();
	}

	[Test]
	public void VerifyBindableLayoutWithEmptyViewStringAndEmptyViewTemplate()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceEmptyCollection");
		App.Tap("ItemsSourceEmptyCollection");
		App.WaitForElement("EmptyViewString");
		App.Tap("EmptyViewString");
		App.WaitForElement("EmptyViewTemplateGrid");
		App.Tap("EmptyViewTemplateGrid");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("No Template Items Available(Grid View)");
	}

	[Test]
	public void VerifyBindableLayoutWithEmptyViewViewAndEmptyViewTemplate()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceEmptyCollection");
		App.Tap("ItemsSourceEmptyCollection");
		App.WaitForElement("EmptyViewGrid");
		App.Tap("EmptyViewGrid");
		App.WaitForElement("EmptyViewTemplateGrid");
		App.Tap("EmptyViewTemplateGrid");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("StackLayoutWithBindableLayout");
		App.WaitForElement("No Template Items Available(Grid View)");
	}

	[Test]
	public void VerifyBindableLayoutWithAddItems()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("Dragonfruit");
		App.WaitForElement("AddItems");
		App.Tap("AddItems");
		App.WaitForElement("Dragonfruit");
	}

	[Test]
	public void VerifyBindableLayoutWithAddItemsAtIndex()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("Chikoo");
		App.WaitForElement("IndexEntry");
		App.ClearText("IndexEntry");
		App.EnterText("IndexEntry", "2");
		App.WaitForElement("AddItems");
		App.Tap("AddItems");
		App.WaitForElement("Chikoo");
	}

	[Test]
	public void VerifyBindableLayoutWithRemoveItems()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Spinach");
		App.WaitForElement("RemoveItems");
		App.Tap("RemoveItems");
		App.WaitForNoElement("Spinach");
	}

	[Test]
	public void VerifyBindableLayoutWithRemoveItemsAtIndex()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Broccoli");
		App.WaitForElement("IndexEntry");
		App.ClearText("IndexEntry");
		App.EnterText("IndexEntry", "3");
		App.WaitForElement("RemoveItems");
		App.Tap("RemoveItems");
		App.WaitForNoElement("Broccoli");
	}

	[Test]
	public void VerifyBindableLayoutWithReplaceItems()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Apple");
		App.WaitForNoElement("Cat");
		App.WaitForElement("ReplaceItems");
		App.Tap("ReplaceItems");
		App.WaitForNoElement("Apple");
		App.WaitForElement("Cat");
	}

	[Test]
	public void VerifyBindableLayoutWithReplaceItemsAtIndex()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ItemsSourceObservableCollection");
		App.Tap("ItemsSourceObservableCollection");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Carrot");
		App.WaitForNoElement("Monkey");
		App.WaitForElement("IndexEntry");
		App.ClearText("IndexEntry");
		App.EnterText("IndexEntry", "2");
		App.WaitForElement("ReplaceItems");
		App.Tap("ReplaceItems");
		App.WaitForNoElement("Carrot");
		App.WaitForElement("Monkey");
	}
}