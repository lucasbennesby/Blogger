document.addEventListener("DOMContentLoaded", function () {

    let login = document.querySelector("#log");
    let cadastro = document.querySelector("#cad");
    let formCadastro = document.querySelector("#cardForm");
    let detalhePubli = document.querySelector("#detalhesPubli");
    let userInfoNavBar = document.querySelector("#userInfo");

    if (window.innerWidth <= 768) {

        if (login)
            login.classList.add("btn", "btn-outline-secondary", "mb-1");

        if (cadastro)
            cadastro.classList.add("btn", "btn-outline-secondary");

        if (formCadastro) {
            formCadastro.classList.add("container", "mb-5")
            formCadastro.classList.remove("cardAlt")
        }

        if (detalhePubli)
            detalhePubli.classList.remove("container")   

        if (userInfoNavBar) 
            userInfoNavBar.style.textAlign = "center";

    } else {

        if (login)
            login.classList.remove("btn", "btn-outline-secondary");

        if (cadastro)
            cadastro.classList.remove("btn", "btn-outline-secondary");

        if (formCadastro)
            formCadastro.classList.remove("container")

        if (detalhePubli)
            detalhePubli.classList.add("container")

        if (userInfoNavBar) {
            userInfoNavBar.style.position = "absolute";
            userInfoNavBar.style.right = "0px";
            userInfoNavBar.style.marginRight = "3px";
        }
    }
});