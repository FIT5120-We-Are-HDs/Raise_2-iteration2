
var buildUrl = "/Build";
var loaderUrl = buildUrl + "/UpdatedNat.loader.js";
var config = {
    dataUrl: buildUrl + "/UpdatedNat.data",
    frameworkUrl: buildUrl + "/UpdatedNat.framework.js",
    codeUrl: buildUrl + "/UpdatedNat.wasm",
    streamingAssetsUrl: "StreamingAssets",
    companyName: "RISE",
    productName: "Life of Natalie",
    productVersion: "1.0",
};

var container = document.querySelector("#unity-container");
console.log(container);
var canvas = document.querySelector("#unity-canvas");
console.log(canvas);
var loadingBar = document.querySelector("#unity-loading-bar");
var progressBarFull = document.querySelector("#unity-progress-bar-full");
var fullscreenButton = document.querySelector("#unity-fullscreen-button");
var mobileWarning = document.querySelector("#unity-mobile-warning");

// By default Unity keeps WebGL canvas render target size matched with
// the DOM size of the canvas element (scaled by window.devicePixelRatio)
// Set this to false if you want to decouple this synchronization from
// happening inside the engine, and you would instead like to size up
// the canvas DOM size and WebGL render target sizes yourself.
// config.matchWebGLToCanvasSize = false;

if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
    container.className = "unity-mobile";
    // Avoid draining fillrate performance on mobile devices,
    // and default/override low DPI mode on mobile browsers.
    config.devicePixelRatio = 1;
    mobileWarning.style.display = "block";
    setTimeout(() => {
        mobileWarning.style.display = "none";
    }, 5000);
} else {
    canvas.style.width = "960px";
    canvas.style.height = "600px";
}
loadingBar.style.display = "block";

var script = document.createElement("script");
script.src = loaderUrl;
script.onload = () => {
    createUnityInstance(canvas, config, (progress) => {
        progressBarFull.style.width = 100 * progress + "%";
    }).then((unityInstance) => {
        loadingBar.style.display = "none";
        fullscreenButton.onclick = () => {
            unityInstance.SetFullscreen(1);
        };
    }).catch((message) => {
        alert(message);
    });
};
document.body.appendChild(script);
