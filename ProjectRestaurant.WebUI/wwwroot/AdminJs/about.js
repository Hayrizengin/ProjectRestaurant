document.getElementById("deleteAboutImage").addEventListener("click", function () {
    const image = document.getElementById("aboutImage");
    image.src = '/AdminUI/assets/img/card.jpg'; // Resmi gizlemek için display özelliğini none yap
});

