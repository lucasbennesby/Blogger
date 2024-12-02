const visualizarSenha = document.getElementById("visualizarSenha");
const inputSenha = document.getElementById("Senha");
const inputConfirmarSenha = document.getElementById("ConfirmarSenha")

visualizarSenha.addEventListener("change", (e) => {
    if (e.currentTarget.checked) {
        if (inputConfirmarSenha != null) {
            inputSenha.setAttribute("type", "text");
            inputConfirmarSenha.setAttribute("type", "text");
        }
         inputSenha.setAttribute("type", "text");
    }
    else {
        if (inputConfirmarSenha != null) {
            inputSenha.setAttribute("type", "password");
            inputConfirmarSenha.setAttribute("type", "password");
        }
         inputSenha.setAttribute("type", "password");
    }
 })
