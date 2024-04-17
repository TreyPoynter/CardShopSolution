window.addEventListener("scroll", () => {
    const nav = document.getElementById("navbar")
    const upper = document.getElementById("upper-nav");
    const middle = document.getElementById("middle-nav");
    const below = document.getElementById("bottom-nav");

    if (window.scrollY >= 124) {
        upper.classList.add("invisable");
        below.classList.add("invisable");
        nav.classList.add("fixed-top")
    } else {
        upper.classList.remove("invisable");
        below.classList.remove("invisable");
        nav.classList.remove("fixed-top")
    }
});