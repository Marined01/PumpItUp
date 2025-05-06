function generateAvatar(text, foregroundColor, backgroundColor) {
    const canvas = document.createElement("canvas");
    const context = canvas.getContext("2d");
    
    canvas.width = 300;
    canvas.height = 300;
    
    context.fillStyle = backgroundColor || "#6a0dad";
    context.fillRect(0, 0, canvas.width, canvas.height);
    
    context.font = "bold 100px Arial";
    context.fillStyle = foregroundColor || "#ffffff";
    context.textAlign = "center";
    context.textBaseline = "middle";
    context.fillText(text, canvas.width / 2, canvas.height / 2);
    
    return canvas.toDataURL("image/png");
}

