using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Maui.Controls.Sample;

public class BindableLayoutViewModel : INotifyPropertyChanged
{
	private object _emptyView;
	private DataTemplate _emptyViewTemplate;
	private DataTemplate _itemTemplate;
	private DataTemplateSelector _itemTemplateSelector;
	private ItemsSourceType _itemsSourceType = ItemsSourceType.ObservableCollectionT;
	private ObservableCollection<CollectionViewTestItem> _observableCollection;
	private ObservableCollection<CollectionViewTestItem> _emptyObservableCollection;

	public event PropertyChangedEventHandler PropertyChanged;

	public BindableLayoutViewModel()
	{
		LoadItems();
		ItemTemplate = new DataTemplate(() =>
			{
				var stackLayout = new StackLayout
				{
					Padding = new Thickness(10),
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};

				var label = new Label
				{
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center
				};
				label.SetBinding(Label.TextProperty, "Caption");
				stackLayout.Children.Add(label);
				return stackLayout;
			});

		// Default selector uses two simple templates alternating by index
		ItemTemplateSelector = new CustomDataTemplateSelector
		{
			Template1 = new DataTemplate(() =>
			{
				var lbl = new Label { TextColor = Colors.Black };
				lbl.SetBinding(Label.TextProperty, "Caption");
				return lbl;
			}),
			Template2 = new DataTemplate(() =>
			{
				var grid = new Grid { BackgroundColor = Colors.LightGray, Padding = new Thickness(6) };
				var lbl = new Label { TextColor = Colors.Blue };
				lbl.SetBinding(Label.TextProperty, "Caption");
				grid.Children.Add(lbl);
				return grid;
			})
		};
	}

	public object EmptyView
	{
		get => _emptyView;
		set { _emptyView = value; OnPropertyChanged(); }
	}

	public DataTemplate EmptyViewTemplate
	{
		get => _emptyViewTemplate;
		set { _emptyViewTemplate = value; OnPropertyChanged(); }
	}

	public DataTemplate ItemTemplate
	{
		get => _itemTemplate;
		set { _itemTemplate = value; OnPropertyChanged(); }
	}

	public DataTemplateSelector ItemTemplateSelector
	{
		get => _itemTemplateSelector;
		set
		{
			if (_itemTemplateSelector != value)
			{
				_itemTemplateSelector = value;
				// prevent both ItemTemplate and ItemTemplateSelector being set; if selector is set, clear template
				if (_itemTemplateSelector != null && _itemTemplate != null)
				{
					_itemTemplate = null;
					OnPropertyChanged(nameof(ItemTemplate));
				}
				OnPropertyChanged();
			}
		}
	}

	public ItemsSourceType ItemsSourceType
	{
		get => _itemsSourceType;
		set
		{
			if (_itemsSourceType != value)
			{
				_itemsSourceType = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ItemsSource));
			}
		}
	}

	public object ItemsSource
	{
		get
		{
			return ItemsSourceType switch
			{
				ItemsSourceType.ObservableCollectionT => _observableCollection,
				ItemsSourceType.EmptyObservableCollectionT => _emptyObservableCollection,
				ItemsSourceType.None => null,
				_ => null
			};
		}
	}

	private void LoadItems()
	{
		_observableCollection = new ObservableCollection<CollectionViewTestItem>();
		AddItems(_observableCollection, 2, "Fruits");
		AddItems(_observableCollection, 3, "Vegetables");

		_emptyObservableCollection = new ObservableCollection<CollectionViewTestItem>();
	}

	private void AddItems(IList<CollectionViewTestItem> list, int count, string category)
	{
		string[] fruits =
		{
			"Apple", "Banana", "Orange", "Grapes", "Mango",
			"Pineapple", "Strawberry", "Blueberry", "Peach", "Cherry",
			"Watermelon", "Papaya", "Kiwi", "Pear", "Plum",
			"Avocado", "Fig", "Guava", "Lychee", "Pomegranate",
			"Lime", "Lemon", "Coconut", "Apricot", "Blackberry"
		};

		string[] vegetables =
		{
			"Carrot", "Broccoli", "Spinach", "Potato", "Tomato",
			"Cucumber", "Lettuce", "Onion", "Garlic", "Pepper",
			"Zucchini", "Pumpkin", "Radish", "Beetroot", "Cabbage",
			"Sweet Potato", "Turnip", "Cauliflower", "Celery", "Asparagus",
			"Eggplant", "Chili", "Corn", "Peas", "Mushroom"
		};

		string[] items = category == "Fruits" ? fruits : vegetables;

		for (int n = 0; n < count; n++)
		{
			list.Add(new CollectionViewTestItem(items[n % items.Length], n));
		}
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public class CustomDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate Template1 { get; set; }
		public DataTemplate Template2 { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			if (item is CollectionViewTestItem testItem)
			{
				return testItem.Index % 2 == 0 ? Template1 : Template2;
			}

			return Template1;
		}
	}

	public class CollectionViewTestItem
	{
		public string Caption { get; set; }
		public int Index { get; set; }

		public CollectionViewTestItem(string caption, int index)
		{
			Caption = caption;
			Index = index;
		}
	}
}