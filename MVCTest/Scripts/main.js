var colorBandObj = {};

// POST resistors band A, B, C, D to controller for calculation via AJAX and update the DOM with value    
function calculateResistor() {
    var resistor = document.querySelector("#value");
    var tolerance = document.querySelector("#tolerance");

    $.ajax({
        type: 'post',
        dataType: "json",
        contentType: "application/json",
        url: '/ResistorController',
        data: JSON.stringify(colorBandObj),
        success: function (res) {
            let resistorVal = JSON.parse(res);
            resistor.innerHTML = resistorVal.resistance;
            tolerance.innerHTML = resistorVal.tolerance + "%";
        }
    })
}


document.onreadystatechange = function () {
    'use strict';

    /*
	 * Fade in and out animation by chrisbuttery
	 * Github - https://github.com/chrisbuttery
	 */
    function fadeIn(el) {
        el.style.opacity = 0;
        el.style.display = "block";

        (function fade() {
            var val = parseFloat(el.style.opacity);
            if (!((val += 0.1) >= 1.1)) {
                el.style.opacity = val;
                requestAnimationFrame(fade);
            }
        }());
    }

    function fadeOut(el) {
        (function fade() {
            var val = parseFloat(el.style.opacity);
            if ((val -= 0.1) == 0) {
                el.style.opacity = 0;
                el.style.display = "none";
            } else {
                el.style.opacity = val;
                requestAnimationFrame(fade);
            }
        }());
    }

        /*
	 *	Waiting for the ready state of the browser
	 * This is to make sure all the elements are loaded in the DOM
	 */

    if (document.readyState === "complete") {

        // Initialise all the required variables
        var btn = document.querySelectorAll(".btn"), first, second, third, fourth, tolerance, resistance = 0;

        /*
		 *	Button click event listeners
		 *	Keeps track of the button click.
		 */
        btn.forEach(function (btn) {
            btn.addEventListener("click", function (e) {
                e.stopPropagation();
                var sibling = btn.nextElementSibling,
					firstVisible = document.querySelector('.visible'),
					dropDown;

                /*
				 * Remove the visible class if an element is already in the DOM
				 */
                if (firstVisible) {
                    fadeOut(firstVisible);
                    firstVisible.classList.remove("visible");
                }

                if (!sibling.classList.contains("visible")) {
                    fadeIn(sibling);
                    sibling.classList.add("visible");
                } else {
                    fadeOut(sibling);
                    sibling.classList.remove("visible");
                }

                /*
				 * Click event for the List items
				 */
                dropDown = document.querySelector('.visible');

                dropDown.addEventListener("click", function (e) {
                    if (e.target.nodeName === 'LI') {
                        var parent = e.target.parentElement.previousElementSibling;

                        if (parent.classList.contains('first')) {
                            first = e.target.innerHTML;
                            if (first == 0) {
                                return false;
                            }
                        }

                        if (parent.classList.contains('second')) {
                            second = e.target.innerHTML;
                        }

                        if (parent.classList.contains('third')) {
                            third = e.target.innerHTML;
                        }

                        if (parent.classList.contains('fourth')) {
                            fourth = e.target.innerHTML;
                        }

                        if (e.target.innerHTML === "Yellow" || e.target.innerHTML === "White" || e.target.innerHTML === "Transparent") {
                            parent.style.color = "black";
                        } else {
                            parent.style.color = "#fff";
                        }
                        parent.classList.add('4-band-set');

                        parent.style.backgroundColor = e.target.innerHTML;

                        if (first !== undefined && second !== undefined && third !== undefined && fourth != undefined) {
                            colorBandObj = {
                                'bandAColor': first,
                                'bandBColor': second,
                                'bandCColor': third,
                                'bandDColor': fourth 
                            }


                        }
                    }
                });
            });
        });

        document.addEventListener("click", function () {
            var visible = document.querySelector(".visible");

            if (visible) {
                fadeOut(visible);
                visible.classList.remove("visible");
            }
        });

    }
};