const mainContainer = document.getElementById("main-container");
const popupContainer = document.getElementById("popup-container");
const shortenButton = document.getElementById("url-input-button");
const closePopupButton = document.getElementById("close-popup");
const copyButton = document.getElementById("copy-button");
const shortUrlSpan = document.getElementById("shortened-url");
const longUrl = document.getElementById("url-input");

shortenButton.addEventListener("click", () => {
    popupContainer.style.display = "flex";

    shortUrlSpan.textContent = "ERROR";
    fetch('http://localhost:5122/shorten', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({longUrl: longUrl.value})
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            shortUrlSpan.textContent = data.shortUrl;
        })
        .catch(error => console.error('Error:', error))
    ;
});

copyButton.addEventListener("click", () => {
    navigator.clipboard.writeText(shortUrlSpan.textContent).then(() => {
        console.log('Short url copied to clipboard!');
        copyButton.style.backgroundColor = "#08ec09";
    }).catch(err => {
        console.error('Failed to copy the short url: ', err);
    });
});

closePopupButton.addEventListener("click", () => {
    popupContainer.style.display = "none";
    shortUrlSpan.textContent = "";
});

