function updateFileName(input) {
    const paragraphs = input.parentElement.querySelectorAll('.file-upload-design p');

    if (input.files.length > 0) {
        const fileName = input.files[0].name;
        const browseButton = input.parentElement.querySelector('.browse-button');
        browseButton.textContent = fileName;

        // Show the paragraphs
        paragraphs.forEach(paragraph => {
            paragraph.style.display = 'none';
        });
    }
}