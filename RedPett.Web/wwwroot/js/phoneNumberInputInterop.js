function initializePhoneNumberInput(element) {
    window.intlTelInput(element);
}
window.initializePhoneNumberInput = function (phoneInputRef) {
    const inputElement = phoneInputRef.current;

    // Initialize intlTelInput
    const iti = window.intlTelInput(inputElement, {
        initialCountry: "us", // Change this to your desired default country
        utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js", // Path to the utils.js file
    });

    // Set up a Blazor event handler to update the phone number value
    inputElement.addEventListener("countrychange", function () {
        // Call a Blazor method to update the phone number value in the component
        DotNet.invokeMethodAsync("YourAppName", "UpdatePhoneNumber", iti.getNumber());
    });
};
