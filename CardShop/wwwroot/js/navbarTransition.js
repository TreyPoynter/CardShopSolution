window.addEventListener("scroll", () => {
    const navbar = document.getElementById("navbar");
    const navItems = document.getElementById("nav-items");

    if (window.scrollY >= 33) {
        navbar.classList.add("fixed-top");
        navItems.classList.remove("py-3");
    } else {
        navbar.classList.remove("fixed-top");
        navItems.classList.add("py-3");
    }
});