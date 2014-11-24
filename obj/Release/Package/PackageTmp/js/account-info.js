function StateCheckChanged(sender)
{
	var hdnStates = $('#hdnStates');
	var dropdown = "ddlDisplayStates";

	UpdateDisplayHiddenField(hdnStates, dropdown);
	DisplayCities();
};

function CityCheckChanged(sender)
{
	var hdnCities = $('#hdnCities');
	var dropdown = "ddlDisplayCities";

	UpdateDisplayHiddenField(hdnCities, dropdown);
};

function CategoryCheckChanged(sender)
{
	var hdnCategories = $('#hdnCategories');
	var dropdown = "ddlDisplayCategories";

	UpdateDisplayHiddenField(hdnCategories, dropdown);
};

function DisplayCities()
{
	var Cities = {};
	var cityCount = 0;
	var citiesUL = $("ul[id*='ddlDisplayCities']");

	Cities = JSON.parse($('#hdnCitiesJSON').val());
	$(citiesUL[0]).empty();

	// Create List items for cities in checked state.
	$('input:checkbox[id*="ddlDisplayStates"]').each(function (index, value)
	{
		if ($(this).prop('checked'))
		{
			var stateID = $(this).val();

			$(Cities).each(function (index, value)
			{
				if (this.StateID == stateID)
				{
					var li = document.createElement('li');
					var checkbox = document.createElement('input');
					checkbox.type = 'checkbox';
					checkbox.id = 'ddlDisplayCities_' + cityCount;
					checkbox.value = this.CityID;
					$(checkbox).change(function ()
					{
						CityCheckChanged(this);
					});

					var label = document.createElement('label');
					label.for = 'ddlDisplayCities_' + cityCount;
					label.innerHTML = " " + this.DisplayName;

					citiesUL[0].appendChild(li);
					li.appendChild(checkbox);
					li.appendChild(label);

					cityCount++;
				}
			});
		}
	});
};

function UpdateDisplayHiddenField(hiddenField, dropdown)
{
	$(hiddenField).val("");

	$('input:checkbox[id*="' + dropdown + '"]').each(function (index, value)
	{
		if ($(this).prop('checked'))
		{
			if ($(hiddenField).val() != '')
			{
				$(hiddenField).val($(hiddenField).val() + ',' + $(this).val());
			}
			else
			{
				$(hiddenField).val($(this).val());
			}
		}
	});

};