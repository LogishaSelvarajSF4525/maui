// Material3 Slider tests reuse the existing Slider Feature Matrix HostApp page.
// The native Android Slider uses Material3 styling (Google Material3 Slider) when Material3 is enabled,
// so these tests produce separate screenshot baselines under the Material3 category.
#if ANDROID
using System;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.Material3)]
public class Material3SliderFeatureTests : _GalleryUITest
{
	public override string GalleryPageName => "Slider Feature Matrix";

	public Material3SliderFeatureTests(TestDevice device)
		: base(device)
	{
	}

	[Test, Order(1)]
	public void Material3Slider_SetEnabledStateToFalse_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseRadio");
		App.Tap("IsEnabledFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(2)]
	public void Material3Slider_ChangeFlowDirection_RTL_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTL");
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(3)]
	public void Material3Slider_SetVisibilityToFalse_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleFalseRadio");
		App.Tap("IsVisibleFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(4)]
	public void Material3Slider_ChangeThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbColorGreenButton");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(5)]
	public void Material3Slider_ChangeMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(6)]
	public void Material3Slider_ChangeMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(7)]
	public void Material3Slider_ChangeBackgroundColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("BackgroundColorLightBlueButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(8)]
	public void Material3Slider_ChangeThumbImageSource_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbImageSourceButton");
		App.Tap("ThumbImageSourceButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(9)]
	public void Material3Slider_SetValueAndMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ValueEntry");
		App.EnterText("ValueEntry", "1");
		App.PressEnter();
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(10)]
	public void Material3Slider_SetValueAndMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ValueEntry");
		App.EnterText("ValueEntry", "0");
		App.PressEnter();
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(11)]
	public void Material3Slider_SetValueAndThumbImageSource_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ValueEntry");
		App.EnterText("ValueEntry", "0");
		App.PressEnter();
		App.Tap("ThumbImageSourceButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(12)]
	public void Material3Slider_SetValueAndFlowDirection_RTL_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ValueEntry");
		App.EnterText("ValueEntry", "0");
		App.PressEnter();
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(13)]
	public void Material3Slider_SetThumbAndMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbColorGreenButton");
		App.Tap("ThumbColorGreenButton");
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(14)]
	public void Material3Slider_SetThumbAndMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbColorGreenButton");
		App.Tap("ThumbColorGreenButton");
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(15)]
	public void Material3Slider_SetThumbAndBackgroundColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbColorGreenButton");
		App.Tap("ThumbColorGreenButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(16)]
	public void Material3Slider_SetThumbColorAndThumbImageSource_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbColorGreenButton");
		App.Tap("ThumbColorGreenButton");
		App.Tap("ThumbImageSourceButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(17)]
	public void Material3Slider_SetMinTrackAndMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(18)]
	public void Material3Slider_SetMinTrackAndBackgroundColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(19)]
	public void Material3Slider_SetMinTrackColorAndFlowDirection_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(20)]
	public void Material3Slider_SetMaxTrackAndBackgroundColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(21)]
	public void Material3Slider_SetMaxTrackColorAndFlowDirection_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(22)]
	public void Material3Slider_SetIsEnableAndThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledTrueRadio");
		App.Tap("IsEnabledTrueRadio");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(23)]
	public void Material3Slider_SetIsEnableAndMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledTrueRadio");
		App.Tap("IsEnabledTrueRadio");
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(24)]
	public void Material3Slider_SetIsEnableAndMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledTrueRadio");
		App.Tap("IsEnabledTrueRadio");
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(25)]
	public void Material3Slider_SetIsEnableAndBackgroundColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledTrueRadio");
		App.Tap("IsEnabledTrueRadio");
		App.Tap("BackgroundColorLightBlueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(26)]
	public void Material3Slider_SetIsVisibleAndThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleTrueRadio");
		App.Tap("IsVisibleTrueRadio");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(27)]
	public void Material3Slider_SetIsVisibleAndMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleTrueRadio");
		App.Tap("IsVisibleTrueRadio");
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(28)]
	public void Material3Slider_SetIsVisibleAndMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleTrueRadio");
		App.Tap("IsVisibleTrueRadio");
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(29)]
	public void Material3Slider_SetIsVisibleAndBackgroundColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleTrueRadio");
		App.Tap("BackgroundColorLightBlueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_ANDROID // Resetting ThumbImageSource to null does not restore the default thumb on Material3 Slider
	[Test, Order(30)]
	public void Material3Slider_SetThumbImageSourceAndReset_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbImageSourceButton");
		App.Tap("ThumbImageSourceButton");
		App.Tap("ThumbImageResetButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

#if TEST_FAILS_ON_ANDROID // Setting Minimum=10 with default Maximum=1 causes IllegalStateException in Material3 Slider (valueFrom must be < valueTo)
	[Test, Order(31)]
	public void Material3Slider_SetMinimumAndChangeFlowDirection_RTL()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinimumEntry");
		App.EnterText("MinimumEntry", "10");
		App.PressEnter();
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

	[Test, Order(32)]
	public void Material3Slider_SetMaximumAndChangeFlowDirection_RTL()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaximumEntry");
		App.EnterText("MaximumEntry", "50");
		App.PressEnter();
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(35)]
	public void Material3Slider_SetMinTrackColorAndValue_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.EnterText("ValueEntry", "1");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetValueAndMinTrackColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(36)]
	public void Material3Slider_SetMinTrackAndThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetThumbAndMinTrackColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(37)]
	public void Material3Slider_SetMinTrackColorTestFlowDirection_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinTrackColorYellowButton");
		App.Tap("MinTrackColorYellowButton");
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetMinTrackColorAndFlowDirection_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(38)]
	public void Material3Slider_SetMaxTrackColorAndValue_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.EnterText("ValueEntry", "0");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetValueAndMaxTrackColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(39)]
	public void Material3Slider_SetMaxTrackAndThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetThumbAndMaxTrackColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(40)]
	public void Material3Slider_SetMaxTrackAndMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetMinTrackAndMaxTrackColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(41)]
	public void Material3Slider_SetMaxTrackColorTestFlowDirection_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxTrackColorRedButton");
		App.Tap("MaxTrackColorRedButton");
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetMaxTrackColorAndFlowDirection_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(42)]
	public void Material3Slider_SetBackgroundColorAndThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("BackgroundColorLightBlueButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetThumbAndBackgroundColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(43)]
	public void Material3Slider_SetBackgroundColorAndMinTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("BackgroundColorLightBlueButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.Tap("MinTrackColorYellowButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetMinTrackAndBackgroundColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(44)]
	public void Material3Slider_SetBackgroundColorAndMaxTrackColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("BackgroundColorLightBlueButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.Tap("MaxTrackColorRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetMaxTrackAndBackgroundColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(45)]
	public void Material3Slider_SetBackgroundColorAndIsEnable_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("BackgroundColorLightBlueButton");
		App.Tap("BackgroundColorLightBlueButton");
		App.Tap("IsEnabledTrueRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetIsEnableAndBackgroundColor_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(46)]
	public void Material3Slider_SetThumbImageSourceAndThumbColor_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThumbImageSourceButton");
		App.Tap("ThumbImageSourceButton");
		App.Tap("ThumbColorGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_ANDROID // Setting Minimum=10 with default Maximum=1 causes IllegalStateException in Material3 Slider (valueFrom must be < valueTo)
	[Test, Order(47)]
	public void Material3Slider_FlowDirection_RTL_SetMinimumValue_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTL");
		App.Tap("FlowDirectionRTL");
		App.EnterText("MinimumEntry", "10");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

	[Test, Order(48)]
	public void Material3Slider_FlowDirection_RTL_SetMaximumValue_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTL");
		App.Tap("FlowDirectionRTL");
		App.EnterText("MaximumEntry", "50");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetMaximumAndChangeFlowDirection_RTL",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(49)]
	public void Material3Slider_FlowDirection_RTL_SetValue_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTL");
		App.Tap("FlowDirectionRTL");
		App.EnterText("ValueEntry", "0");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot("Material3Slider_SetValueAndFlowDirection_RTL_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}


	[Test, Order(50)]
	public void Material3Slider_SetHeightRequest_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("HeightRequestEntry");
		App.ClearText("HeightRequestEntry");
		App.EnterText("HeightRequestEntry", "80");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(51)]
	public void Material3Slider_SetWidthRequest_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("WidthRequestEntry");
		App.ClearText("WidthRequestEntry");
		App.EnterText("WidthRequestEntry", "200");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(52)]
	public void Material3Slider_SetOpacity_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("OpacityEntry");
		App.ClearText("OpacityEntry");
		App.EnterText("OpacityEntry", "0.3");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[TestCase("Start")]
	[TestCase("Center")]
	[TestCase("End")]
	[Order(53)]
	public void Material3Slider_SetVerticalOptions_VerifyVisualState(string verticalOption)
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.ScrollTo($"VerticalOptions{verticalOption}Radio");
		App.Tap($"VerticalOptions{verticalOption}Radio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("MinimumValueLabel");
		VerifyScreenshot($"Material3Slider_VerticalOptions{verticalOption}_VerifyVisualState",
			tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	void DragSlider(int startPercent, int endPercent)
	{
		var sliderRect = App.WaitForElement("SliderGrid").GetRect();
		var startX = sliderRect.X + (sliderRect.Width * startPercent / 100);
		var centerY = sliderRect.Y + (sliderRect.Height / 2);
		var endX = sliderRect.X + (sliderRect.Width * endPercent / 100);
		App.DragCoordinates(startX, centerY, endX, centerY);
	}

	[Test, Order(33)]
	public void Material3Slider_DragStartedAndCompletedEventTriggered()
	{
		App.WaitForElement("SliderGrid");
		DragSlider(30, 70);
		App.WaitForTextToBePresentInElement("DragStartStatusLabel", "Drag Started");
		App.WaitForTextToBePresentInElement("DragCompletedStatusLabel", "Drag Completed");
	}

	[Test, Order(34)]
	public void Material3Slider_ValueChangedEvent_FiredOnDrag()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "0");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("SliderGrid");

		App.WaitForTextToBePresentInElement("ValueChangedEventStatus", "Not Raised");

		DragSlider(10, 60);
		App.WaitForTextToBePresentInElement("ValueChangedEventStatus", "Raised");
	}
}
#endif
