﻿window.addEventListener("scroll", () => {
    const middle = document.getElementById("fixed-middle-nav");

    if (window.scrollY >= 124) {
        middle.classList.remove("invisible");
    } else {
        middle.classList.add("invisible");
    }
});