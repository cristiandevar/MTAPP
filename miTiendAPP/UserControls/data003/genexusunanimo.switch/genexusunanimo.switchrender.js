function GeneXusUnanimo_Switch($) {
	  
	  
	  

	var template = '<div class=\"switch-container stack-top-l\">    <input id=\"switch{{id}}\" name=\"gxSwitch{{id}}\" type=\"checkbox\" data-gx-binding=\"checked\" {{^Enabled}}disabled{{/Enabled}}/>    <label for=\"switch{{id}}\"></label></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	var valueObject = {};

	this.setAttribute = function (v) {
		valueObject.value = gx.lang.gxBoolean(v);
	}
	this.getAttribute = function () {
		var v = valueObject.value;
		return v;
	}

	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			var $dataElement = $container.find("[data-gx-binding]");
			var dataElementProp = $dataElement.attr("data-gx-binding") || "value";
			$dataElement.on("input", function () {
				valueObject.value = gx.lang.gxBoolean(this[dataElementProp]);
			});
			$dataElement.on("change", function () {
				valueObject.value = gx.lang.gxBoolean(this[dataElementProp]);
			});
			$dataElement.on("focus", this.onfocus.closure(this));
			$dataElement.on("input", this.oninput.closure(this));
			$dataElement.on("change", this.onchange.closure(this));

			$dataElement.prop(dataElementProp, valueObject.value);



			// Raise after show scripts

	}

	this.Scripts = [];




	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}