using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests
{

	[Category(UITestCategories.Slider)]
	public class SliderFeatureTests : _GalleryUITest
	{
		public const string SliderFeatureMatrix = "Slider Feature Matrix";

		public override string GalleryPageName => SliderFeatureMatrix;

		public SliderFeatureTests(TestDevice device)
			: base(device)
		{
		}

		[Test, Order(1)]
		public void Slider_ValidateDefaultValues_VerifyLabels()
		{
			App.WaitForElement("Options");
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("0.00"));
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("1.00"));
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
		}

		[Test, Order(2)]
		public void Slider_SetMinimumValue_VerifyMaximumLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "3");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("3.00"));
		}

		[Test, Order(3)]
		public void Slider_SetMaximumValue_VerifyMinimumLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "20");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("20.00"));
		}

		[Test, Order(4)]
		public void Slider_SetCurrentValue_VerifyValueLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ValueEntry");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("1.00"));
		}

		[Test, Order(5)]
		public void Slider_SetValueExceedsMaximum()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "100");
			App.PressEnter();
			App.EnterText("ValueEntry", "150");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("100.00"));
		}

		[Test, Order(6)]
		public void Slider_SetValueWithinRange()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "100");
			App.PressEnter();
			App.EnterText("ValueEntry", "50");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("50.00"));
		}

		[Test, Order(7)]
		public void Slider_SetMinimumValue_CheckValueLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "-5");
			App.PressEnter();
			App.EnterText("ValueEntry", "-2");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("-2.00"));
		}

		[Test, Order(8)]
		public void Slider_MinimumExceedsMaximum_VerifyMaximumLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "50");
			App.PressEnter();
			App.EnterText("MaximumEntry", "25");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("25.00"));
		}
		[Test, Order(9)]
		public void Slider_ValueAboveMaximum_CheckMaximumLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.EnterText("ValueEntry", "70");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("50.00"));
		}

		[Test, Order(10)]
		public void Slider_SetNegativeMinimum_DoesNotChangeDefaultMaximum()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "-1");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("1.00"));
		}

		[Test, Order(11)]
		public void Slider_CurrentValueHigherThanMinimumAndMaximum_ClampsToMaximum()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.EnterText("ValueEntry", "60");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("50.00"));
		}

		[Test, Order(12)]
		public void Slider_CurrentValueIsSetToMinimum()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.EnterText("MaximumEntry", "20");
			App.PressEnter();
			App.EnterText("ValueEntry", "15");
			App.PressEnter();
			App.ClearText("MinimumEntry");
			App.EnterText("MinimumEntry", "20");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("20.00"));
		}

		[Test, Order(13)]
		public void Slider_SetMinimumAboveMaximum()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.EnterText("MinimumEntry", "60");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("60.00"));
		}

		[Test, Order(14)]
		public void Slider_ValueBelowMinimum_CheckMinimumLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "20");
			App.PressEnter();
			App.EnterText("ValueEntry", "10");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("20.00"));
		}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS // SetSliderValue method not supported on Catalyst and windows
		[Test, Order(15)]
		public void Slider_DragStartedAndCompletedEventTrigged()
		{
			App.WaitForElement("Options");
			App.SetSliderValue("SliderControl", 0, 1);
			Task.Delay(TimeSpan.FromSeconds(1)).Wait();
			Assert.That(App.WaitForElement("DragStartStatusLabel").GetText(), Is.EqualTo("Drag Started"));
			Assert.That(App.WaitForElement("DragCompletedStatusLabel").GetText(), Is.EqualTo("Drag Completed"));
		}
#endif

		[Test, Order(16)]
		public void Slider_SetEnabledStateToFalse_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledFalseRadio");
			App.Tap("IsEnabledFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(17)]
		public void Slider_ChangeFlowDirection_RTL_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(18)]
		public void Slider_SetVisibilityToFalse_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleFalseRadio");
			App.Tap("IsVisibleFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("Options");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(19)]
		public void Slider_ChangeThumbColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbColorGreenButton");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(20)]
		public void Slider_ChangeMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinTrackColorYellowButton");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(21)]
		public void Slider_ChangeMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaxTrackColorRedButton");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(22)]
		public void Slider_ChangeBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BackgroundColorLightBlueButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(23)]
		public void Slider_ChangeThumbImageSource_VerifyVisualState()
		{
			if (App is AppiumIOSApp iosApp && HelperExtensions.IsIOS26OrHigher(iosApp))
			{
				Assert.Ignore("Ignored due to a bug issue in iOS 26"); // Issue Link: https://github.com/dotnet/maui/issues/33967
			}
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbImageSourceButton");
			App.Tap("ThumbImageSourceButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(24)]
		public void Slider_SetThumbImageSourceAndReset_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbImageSourceButton");
			App.Tap("ThumbImageSourceButton");
			App.Tap("ThumbImageResetButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(25)]
		public void Slider_SetMinimumAndChangeFlowDirection_RTL()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinimumEntry");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(26)]
		public void Slider_SetMaximumAndChangeFlowDirection_RTL()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(27)]
		public void Slider_SetValueAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ValueEntry");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(28)]
		public void Slider_SetValueAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ValueEntry");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(29)]
		public void Slider_SetValueAndThumbImageSource_VerifyVisualState()
		{
			if (App is AppiumIOSApp iosApp && HelperExtensions.IsIOS26OrHigher(iosApp))
			{
				Assert.Ignore("Ignored due to a bug issue in iOS 26"); // Issue Link: https://github.com/dotnet/maui/issues/33967
			}
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ValueEntry");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.Tap("ThumbImageSourceButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(30)]
		public void Slider_SetValueAndFlowDirection_RTL_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ValueEntry");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(31)]
		public void Slider_SetThumbAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbColorGreenButton");
			App.Tap("ThumbColorGreenButton");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(32)]
		public void Slider_SetThumbAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbColorGreenButton");
			App.Tap("ThumbColorGreenButton");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(33)]
		public void Slider_SetThumbAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbColorGreenButton");
			App.Tap("ThumbColorGreenButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(34)]
		public void Slider_SetThumbColorAndThumbImageSource_VerifyVisualState()
		{
			if (App is AppiumIOSApp iosApp && HelperExtensions.IsIOS26OrHigher(iosApp))
			{
				Assert.Ignore("Ignored due to a bug issue in iOS 26"); // Issue Link: https://github.com/dotnet/maui/issues/33967
			}
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbColorGreenButton");
			App.Tap("ThumbColorGreenButton");
			App.Tap("ThumbImageSourceButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(35)]
		public void Slider_SetMinTrackColorAndValue_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinTrackColorYellowButton");
			App.Tap("MinTrackColorYellowButton");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(36)]
		public void Slider_SetMinTrackAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinTrackColorYellowButton");
			App.Tap("MinTrackColorYellowButton");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(37)]
		public void Slider_SetMinTrackAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinTrackColorYellowButton");
			App.Tap("MinTrackColorYellowButton");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(38)]
		public void Slider_SetMinTrackAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinTrackColorYellowButton");
			App.Tap("MinTrackColorYellowButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(39)]
		public void Slider_SetMinTrackColorTestFlowDirection_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MinTrackColorYellowButton");
			App.Tap("MinTrackColorYellowButton");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(40)]
		public void Slider_SetMaxTrackColorAndValue_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaxTrackColorRedButton");
			App.Tap("MaxTrackColorRedButton");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(41)]
		public void Slider_SetMaxTrackAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaxTrackColorRedButton");
			App.Tap("MaxTrackColorRedButton");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(42)]
		public void Slider_SetMaxTrackAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaxTrackColorRedButton");
			App.Tap("MaxTrackColorRedButton");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(43)]
		public void Slider_SetMaxTrackAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaxTrackColorRedButton");
			App.Tap("MaxTrackColorRedButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(44)]
		public void Slider_SetMaxTrackColorTestFlowDirection_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("MaxTrackColorRedButton");
			App.Tap("MaxTrackColorRedButton");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(45)]
		public void Slider_SetIsEnableAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledTrueRadio");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(46)]
		public void Slider_SetIsEnableAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledTrueRadio");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(47)]
		public void Slider_SetIsEnableAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledTrueRadio");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(48)]
		public void Slider_SetIsEnableAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledTrueRadio");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(49)]
		public void Slider_SetIsVisibleAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleTrueRadio");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(50)]
		public void Slider_SetIsVisibleAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleTrueRadio");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(51)]
		public void Slider_SetIsVisibleAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleTrueRadio");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(52)]
		public void Slider_SetIsVisibleAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleTrueRadio");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(53)]
		public void Slider_SetBackgroundColorAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BackgroundColorLightBlueButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(54)]
		public void Slider_SetBackgroundColorAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BackgroundColorLightBlueButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(55)]
		public void Slider_SetBackgroundColorAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BackgroundColorLightBlueButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(56)]
		public void Slider_SetBackgroundColorAndIsEnable_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BackgroundColorLightBlueButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.Tap("IsEnabledTrueRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(57)]

		public void Slider_SetThumbImageSourceAndThumbColor_VerifyVisualState()
		{
			if (App is AppiumIOSApp iosApp && HelperExtensions.IsIOS26OrHigher(iosApp))
			{
				Assert.Ignore("Ignored due to a bug issue in iOS 26"); // Issue Link: https://github.com/dotnet/maui/issues/33967
			}
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ThumbImageSourceButton");
			App.Tap("ThumbImageSourceButton");
			App.Tap("ThumbColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(58)]
		public void Slider_FlowDirection_RTL_SetMinimumValue_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(59)]
		public void Slider_FlowDirection_RTL_SetMaximumValue_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(60)]
		public void Slider_FlowDirection_RTL_SetValue_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(61)]
		public void Slider_SetFlowDirectionAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.Tap("MinTrackColorYellowButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(62)]
		public void Slider_SetFlowDirectionAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.Tap("MaxTrackColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(63)]

		public void Slider_ValueChangedEvent_NotRaised_Initially()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			App.WaitForElement("SliderControl");

			var eventStatus = App.FindElement("ValueChangedEventStatus").GetText();
			Assert.That(eventStatus, Is.EqualTo("Not Raised"));
		}

		[Test, Order(64)]
		public void Slider_ValueChangedEvent_VerifyArguments_FromOptions()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			App.WaitForElement("SliderControl");

			// Initial state
			Assert.That(App.FindElement("ValueChangedEventStatus").GetText(), Is.EqualTo("Not Raised"));

			// Navigate to Options
			App.Tap("Options");

			App.WaitForElement("MaximumEntry");
			App.EnterText("MaximumEntry", "5");
			App.WaitForElement("ValueEntry");

			// Change value
			App.ClearText("ValueEntry");
			App.EnterText("ValueEntry", "2");
			App.PressEnter();

			App.Tap("Apply");

			App.WaitForElement("SliderControl");

			// Event should be raised
			Assert.That(App.FindElement("ValueChangedEventStatus").GetText(), Is.EqualTo("Raised"));

			// Validate event arguments
			Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("0.00"));
			Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("2.00"));
		}

		[Test, Order(65)]
		public void Slider_ValueChangedEvent_ClampedToMaximum_VerifyArguments()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("MaximumEntry");
			App.ClearText("MaximumEntry");
			App.EnterText("MaximumEntry", "1");

			App.ClearText("ValueEntry");
			App.EnterText("ValueEntry", "25");
			App.PressEnter();

			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");

			Assert.That(App.FindElement("ValueChangedEventStatus").GetText(), Is.EqualTo("Raised"));
			Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("0.00"));
			Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("1.00")); // clamped
		}


		[Test, Order(66)]
		public void Slider_ValueBelowMinimum_EventNotRaised_WithClampedValue()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			App.WaitForElement("SliderControl");
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ValueEntry");

			App.ClearText("ValueEntry");
			App.EnterText("ValueEntry", "-10");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");

			App.WaitForElement("SliderControl");

			Assert.That(App.FindElement("ValueChangedEventStatus").GetText(), Is.EqualTo("Not Raised"));
			Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("0.00"));
			Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("0.00"));
		}

		[Test, Order(67)]
		public void Slider_SetHeightRequest_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("HeightRequestEntry");
			App.ClearText("HeightRequestEntry");
			App.EnterText("HeightRequestEntry", "80");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(68)]
		public void Slider_SetWidthRequest_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("WidthRequestEntry");
			App.ClearText("WidthRequestEntry");
			App.EnterText("WidthRequestEntry", "200");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(69)]
		public void Slider_SetOpacity_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("OpacityEntry");
			App.ClearText("OpacityEntry");
			App.EnterText("OpacityEntry", "0.3");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS // SetSliderValue method not supported on Catalyst and windows
		[Test, Order(70)]
		public void Slider_IsEnabledFalse_DragDoesNotChangeValue()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledFalseRadio");
			App.Tap("IsEnabledFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");

			App.SetSliderValue("SliderControl", 0, 1);
			Task.Delay(TimeSpan.FromSeconds(1)).Wait();

			// Value should remain at default (0.00) because the slider is disabled.
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
			Assert.That(App.FindElement("ValueChangedEventStatus").GetText(), Is.EqualTo("Not Raised"));
		}
#endif

		[Test, Order(71)]
		public void Slider_HorizontalOptionsRadioButtons_ChangeAlignment()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("WidthRequestEntry");
			App.EnterText("WidthRequestEntry", "120");
			App.PressEnter();
			App.ScrollTo("HorizontalOptionsStartRadio");
			App.Tap("HorizontalOptionsStartRadio");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			var startX = App.FindElement("SliderControl").GetRect().X;

			App.Tap("Options");
			App.WaitForElement("WidthRequestEntry");
			App.EnterText("WidthRequestEntry", "120");
			App.PressEnter();
			App.ScrollTo("HorizontalOptionsEndRadio");
			App.Tap("HorizontalOptionsEndRadio");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("SliderControl");
			var endX = App.FindElement("SliderControl").GetRect().X;

			Assert.That(endX, Is.GreaterThan(startX));
		}
	}
}
