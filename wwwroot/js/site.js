var darkMode = document.getElementById("darkMode");
// check local storage for current value
darkOn = localStorage.getItem("dark-only") == "true" ? true : false;
setTheme();

function setTheme() {
    //save new value to local storage
    localStorage.setItem("dark-only", darkOn ? "true" : "false");
    if (darkOn) {
        document.body.classList.add('dark-only');
        //document.body.classList.remove('fa-moon-o');
        //document.body.classList.add('fa-lightbulb-o');
    }
    else {
        document.body.classList.remove('dark-only');
        //document.body.classList.remove('fa-lightbulb-o');
        //document.body.classList.add('fa-moon-o');
    }
}


function toggle() {
    darkOn = !darkOn;
    setTheme();
}

darkMode.addEventListener("click", toggle);