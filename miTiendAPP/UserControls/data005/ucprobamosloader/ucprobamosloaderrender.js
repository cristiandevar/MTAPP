function UCProbamosLoader($) {

	var template = '<script>	// Selecciona el nodo que deseas observar	const bodyNode = document.body;		// Configuración del observer: queremos observar cambios en los atributos	const config = { attributes: true, attributeFilter: [\'class\'] };		// Crea una instancia de MutationObserver	const observer = new MutationObserver((mutationsList) => {		for (let mutation of mutationsList) {			setEnabledLoader(mutation.target);			if (mutation.type === \'attributes\' && mutation.attributeName === \'class\' && enabledLoader) {							if (!$(\'.loader\')[0]) {					addLoader()				}						} else if (mutation.type === \'attributes\' && mutation.attributeName === \'class\' && !enabledLoader) {								removeLoader();						}		}	});	observer.observe(bodyNode, config);	function addLoader(){		$(\'head\').append(\'<style id=\"loader\">\' 			+\'		:root {\'			+\'			--hue: 223;\'			+\'			--bg: hsl(var(--hue),10%,90%);\'			+\'			--fg: hsl(var(--hue),10%,10%);\'			+\'			--primary: hsl(var(--hue),90%,55%);\'			+\'			--trans-dur: 0.3s;\'			+\'			font-size: calc(16px + (20 - 16) * (100vw - 320px) / (1280 - 320));\'			+\'		}\'			+\'		.loader {\'			+\'  			position: fixed; /* Fija el loader sobre toda la pantalla */\'			+\'  			top: 0;\'			+\'  			left: 0;\'			+\'		  	width: 100vw; /* Ocupa todo el ancho de la pantalla */\'			+\'  			height: 100vh; /* Ocupa todo el alto de la pantalla */\'			+\'  			background-color: rgba(0, 0, 0, 0.5); /* Fondo grisáceo semi-transparente */\'			+\'  			display: flex; /* Usa flexbox para centrar el contenido */\'			+\'  			align-items: center; /* Centrado vertical */\'			+\'  			justify-content: center; /* Centrado horizontal */\'			+\'  			z-index: 9999; /* Asegúrate de que esté por encima de otros elementos */\'			+\'		}\'									+\'		.preloader {\'			+\'  			text-align: center;\'			+\'  			max-width: 20em;\'			+\'			width: 100%;\'			+\'  			background: none; /* Sin fondo adicional */\'			+\'		}\'			+\'		.preloader__text {\'			+\'			position: relative;\'			+\'			height: 1.5em;\'			+\'		}\'			+\'		.preloader__msg {\'			+\'			animation: msg 0.3s 13.7s linear forwards;\'			+\'			position: absolute;\'			+\'			width: 100%;\'			+\'		}\'			+\'		.preloader__msg--last {\'			+\'			animation-direction: reverse;\'			+\'			animation-delay: 14s;\'			+\'			visibility: hidden;\'			+\'		}\'			+\'		.cart {\'			+\'			display: block;\'			+\'			margin: 0 auto 1.5em auto;\'			+\'			width: 8em;\'			+\'			height: 8em;\'			+\'		}\'			+\'		.cart__lines,\'			+\'		.cart__top,\'			+\'		.cart__wheel1,\'			+\'		.cart__wheel2,\'			+\'		.cart__wheel-stroke {\'			+\'			animation: cartLines 2s ease-in-out infinite;\'			+\'		}\'			+\'		.cart__lines {\'			+\'			stroke: var(--primary);\'			+\'		}\'			+\'		.cart__top {\'			+\'			animation-name: cartTop;\'			+\'		}\'			+\'		.cart__wheel1 {\'			+\'			animation-name: cartWheel1;\'			+\'			transform: rotate(-0.25turn);\'			+\'			transform-origin: 43px 111px;\'			+\'		}\'			+\'		.cart__wheel2 {\'			+\'			animation-name: cartWheel2;\'			+\'			transform: rotate(0.25turn);\'			+\'			transform-origin: 102px 111px;\'			+\'		}\'			+\'		.cart__wheel-stroke {\'			+\'			animation-name: cartWheelStroke\'			+\'		}\'			+\'		.cart__track {\'			+\'			stroke: hsla(var(--hue),10%,10%,0.1);\'			+\'			transition: stroke var(--trans-dur);\'			+\'		}\'			+\'		/* Dark theme */\'			+\'		@media (prefers-color-scheme: dark) {\'			+\'			.cart__track {\'			+\'				stroke: hsla(var(--hue),10%,90%,0.1);\'			+\'			}\'			+\'		}\'			+\'		/* Animations */\'			+\'		@keyframes cartLines {\'			+\'			from,\'			+\'			to {\'			+\'				opacity: 0;\'			+\'			}\'			+\'			8%,\'			+\'			92% {\'			+\'				opacity: 1;\'			+\'			}\'			+\'		}\'			+\'		@keyframes cartTop {\'			+\'			from {\'			+\'				stroke-dashoffset: -338;\'			+\'			}\'			+\'			50% {\'			+\'				stroke-dashoffset: 0;\'			+\'			}\'			+\'			to {\'			+\'				stroke-dashoffset: 338;\'			+\'			}\'			+\'		}\'			+\'		@keyframes cartWheel1 {\'			+\'			from {\'			+\'				transform: rotate(-0.25turn);\'			+\'			}\'			+\'			to {\'			+\'				transform: rotate(2.75turn);\'			+\'			}\'			+\'		}\'			+\'		@keyframes cartWheel2 {\'			+\'			from {\'			+\'				transform: rotate(0.25turn);\'			+\'			}\'			+\'			to {\'			+\'				transform: rotate(3.25turn);\'			+\'			}\'			+\'		}\'			+\'		@keyframes cartWheelStroke {\'			+\'			from,\'			+\'			to {\'			+\'				stroke-dashoffset: 81.68;\'			+\'			}\'			+\'			50% {\'			+\'				stroke-dashoffset: 40.84;\'			+\'			}\'			+\'		}\'				+\'</style>\'		);				var htmlString =			\'<div class=\"loader\"><div class=\"preloader\">\'			+\'	<svg class=\"cart\" role=\"img\" aria-label=\"Shopping cart line animation\" viewBox=\"0 0 128 128\" width=\"128px\" height=\"128px\" xmlns=\"http://www.w3.org/2000/svg\">\'			+\'		<g fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"8\">\'			+\'			<g class=\"cart__track\" stroke=\"hsla(0,10%,10%,0.1)\">\'			+\'				<polyline points=\"4,4 21,4 26,22 124,22 112,64 35,64 39,80 106,80\" />\'			+\'				<circle cx=\"43\" cy=\"111\" r=\"13\" />\'			+\'				<circle cx=\"102\" cy=\"111\" r=\"13\" />\'			+\'			</g>\'			+\'			<g class=\"cart__lines\" stroke=\"currentColor\">\'			+\'				<polyline class=\"cart__top\" points=\"4,4 21,4 26,22 124,22 112,64 35,64 39,80 106,80\" stroke-dasharray=\"338 338\" stroke-dashoffset=\"-338\" />\'			+\'				<g class=\"cart__wheel1\" transform=\"rotate(-90,43,111)\">\'			+\'					<circle class=\"cart__wheel-stroke\" cx=\"43\" cy=\"111\" r=\"13\" stroke-dasharray=\"81.68 81.68\" stroke-dashoffset=\"81.68\" />\'			+\'				</g>\'			+\'				<g class=\"cart__wheel2\" transform=\"rotate(90,102,111)\">\'			+\'					<circle class=\"cart__wheel-stroke\" cx=\"102\" cy=\"111\" r=\"13\" stroke-dasharray=\"81.68 81.68\" stroke-dashoffset=\"81.68\" />\'			+\'				</g>\'			+\'			</g>\'			+\'		</g>\'			+\'	</svg>\'			+\'</div></div>\'		$(\'body\').append(htmlString);	}	function removeLoader(){		$(\'#loader\').remove();		$(\'.loader\').remove();		$(\'.preloader\').remove();	}			function setEnabledLoader(target){		if (target.classList.contains(\"gx-spa-navigating\")){			enabledLoader = true;		} else if (target.classList.contains(\"gx-masked\") && !(target.classList.contains(\"gx-popup-opened\"))) {			enabledLoader = true; 		} else {			enabledLoader = false;		}		}</script>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



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