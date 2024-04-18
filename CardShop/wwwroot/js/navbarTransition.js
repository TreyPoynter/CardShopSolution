window.addEventListener("scroll", () => {
    const middle = document.getElementById("middle-nav");

    if (window.scrollY >= 124) {
        middle.classList.add("fixed-middle-nav");
    } else {
        middle.classList.remove("fixed-middle-nav");
    }
});