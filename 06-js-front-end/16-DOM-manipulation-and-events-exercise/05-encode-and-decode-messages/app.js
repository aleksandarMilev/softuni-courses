function encodeAndDecodeMessages() {
    let sendMessageDiv = document.querySelectorAll('#main > div')[0];
    let receiveMessageDiv = document.querySelectorAll('#main > div')[1];

    let messageSendField = sendMessageDiv.querySelector('textarea');
    let messageReceiveField = receiveMessageDiv.querySelector('textarea');

    let messageSendButton = sendMessageDiv.querySelector('button');
    messageSendButton.addEventListener('click', sendMessage);

    let messageReceiveButton = receiveMessageDiv.querySelector('button');
    messageReceiveButton.disabled = false;
    messageReceiveButton.addEventListener('click', showDecodedMessage);

    function encodeMessage(message) {
        let asciiCodes = [];

        for (let i = 0; i < message.length; i++) {
            let asciiCode = message.charCodeAt(i);
            asciiCodes.push(asciiCode + 1);
        }

        return String.fromCharCode(...asciiCodes);
    }

    function decodeMessage(message) {
        let asciiCodes = [];

        for (let i = 0; i < message.length; i++) {
            let asciiCode = message.charCodeAt(i);
            asciiCodes.push(asciiCode - 1);
        }

        return String.fromCharCode(...asciiCodes);
    }

    function sendMessage() {
        let cryptedMessage = encodeMessage(messageSendField.value);

        messageSendField.value = '';

        messageReceiveField.value = cryptedMessage;

        messageReceiveButton.disabled = false;
    }

    function showDecodedMessage() {
        messageReceiveField.value = decodeMessage(messageReceiveField.value);

        this.disabled = true;
    }
}