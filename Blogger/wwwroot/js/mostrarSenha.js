const visualizarSenha = document.getElementById("visualizarSenha");
const inputSenha = document.getElementById("user-password");
const inputConfirmarSenha = document.getElementById("ConfirmarSenha")
const checkbox = document.getElementById('customCheckbox');
const path = document.getElementById('svgPath')




document.getElementById('visualizarSenha').addEventListener('click', function () {
    console.log("click")
    checkbox.checked = !checkbox.checked; 
    console.log(visualizarSenha)

    if (checkbox.checked) {
        if (inputConfirmarSenha != null) {
            inputSenha.setAttribute("type", "text");
            inputConfirmarSenha.setAttribute("type", "text");
        }
        inputSenha.setAttribute("type", "text");
        path.setAttribute('d', 'M12,9A3,3 0 0,1 15,12A3,3 0 0,1 12,15A3,3 0 0,1 9,12A3,3 0 0,1 12,9M12,4.5C17,4.5 21.27,7.61 23,12C21.27,16.39 17,19.5 12,19.5C7,19.5 2.73,16.39 1,12C2.73,7.61 7,4.5 12,4.5M3.18,12C4.83,15.36 8.24,17.5 12,17.5C15.76,17.5 19.17,15.36 20.82,12C19.17,8.64 15.76,6.5 12,6.5C8.24,6.5 4.83,8.64 3.18,12Z');
    }
    else {
        if (inputConfirmarSenha != null) {
            inputSenha.setAttribute("type", "password");
            inputConfirmarSenha.setAttribute("type", "password");
        }
        inputSenha.setAttribute("type", "password");
        path.setAttribute('d', 'M12 17.5C8.2 17.5 4.8 15.4 3.2 12H1C2.7 16.4 7 19.5 12 19.5S21.3 16.4 23 12H20.8C19.2 15.4 15.8 17.5 12 17.5Z');
    }
});

