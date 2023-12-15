let productos = ["pantalones", "abrigos", "ccamisetas"];

// let currentPage = 1;
let x = 1;
// const pageSize = 4; // Tamaño de la página

// function previousPage() {
//     if (currentPage > x) {
//         currentPage -= x;
//         updateTable();
//     }
// }

// const Next = document.querySelector("#nexte");
// Next.addEventListener('click', () => {
//     nextPage();
// });

// const Previous = document.querySelector("#previouse");
// Previous.addEventListener('click', () => {
//     previousPage();
// });

// function nextPage() {
//     currentPage += x;
//     updateTable();
// }

// function updateTable() {
//     // Lógica para actualizar la tabla con la página actual
//     empleado();
//     document.getElementById("currentPage").textContent = currentPage;
// }




// Llama a la función después de cargar la página o en el momento adecuado

const botonesCategorias = document.querySelectorAll(".boton-categoria");
const pantalone = document.querySelectorAll("#pantalones");
const camiseta = document.querySelectorAll("#camisetas");
const abrigo = document.querySelectorAll("#abrigos");
const tituloPrincipal = document.querySelector("#titulo-principal");
let botonesAgregar = document.querySelectorAll(".producto-agregar");
const numerito = document.querySelector("#numerito");





async function pantalones() {
    let reqData = await fetch(`http://localhost:5149/api/Producto/tipopantalones`);
    let respJson = await reqData.json();
    pantalone.forEach(boton => boton.addEventListener("click", () => {
        try {
            const contenedorProductos = document.querySelector("#contenedor-productos");
            contenedorProductos.innerHTML = "";
            respJson.forEach(producto => {

                const div = document.createElement("div");
                div.classList.add("producto");
                div.innerHTML = /*html*/`
            <img class="producto-imagen" src="${producto.imagen}" alt="${producto.nombre}">
            <div class="producto-detalles">
                <h3 class="producto-titulo">${producto.nombre}</h3>
                <p class="producto-precio">$${producto.precio}</p>
                <button class="producto-agregar" id="${producto.id}">Agregar</button>
            </div>
        `;

                contenedorProductos.append(div);
            });
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }

        actualizarBotonesAgregar();
    }));
}
pantalones();


async function camisetas() {
    let reqData = await fetch(`http://localhost:5149/api/Producto/tipocamisetas`);
    let respJson = await reqData.json();
    camiseta.forEach(boton => boton.addEventListener("click", () => {
        try {
            const contenedorProductos = document.querySelector("#contenedor-productos");
            contenedorProductos.innerHTML = "";
            respJson.forEach(producto => {

                const div = document.createElement("div");
                div.classList.add("producto");
                div.innerHTML = /*html*/`
            <img class="producto-imagen" src="${producto.imagen}" alt="${producto.nombre}">
            <div class="producto-detalles">
                <h3 class="producto-titulo">${producto.nombre}</h3>
                <p class="producto-precio">$${producto.precio}</p>
                <button class="producto-agregar" id="${producto.id}">Agregar</button>
            </div>
        `;

                contenedorProductos.append(div);
            });
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }

        actualizarBotonesAgregar();
    }))
}
camisetas();

async function cargarProductos() {
    try {
        let reqData = await fetch(`http://localhost:5149/api/Producto`);
        let respJson = await reqData.json();
        const contenedorProductos = document.querySelector("#contenedor-productos");
        contenedorProductos.innerHTML = "";
        respJson.forEach(producto => {

        const div = document.createElement("div");
        div.classList.add("producto");
        div.innerHTML = /*html*/`
            <img class="producto-imagen" src="${producto.imagen}" alt="${producto.nombre}">
            <div class="producto-detalles">
                <h3 class="producto-titulo">${producto.nombre}</h3>
                <p class="producto-precio">$${producto.precio}</p>
                <button class="producto-agregar" id="${producto.id}">Agregar</button>
            </div>
        `;

        contenedorProductos.append(div);
    });
    } catch (error) {
        console.error('Error al obtener datos:', error);
    }

    actualizarBotonesAgregar();
}

cargarProductos();


botonesCategorias.forEach(boton => {
    boton.addEventListener("click", (e) => {

        botonesCategorias.forEach(boton => boton.classList.remove("active"));
        e.currentTarget.classList.add("active");

        if (e.currentTarget.id != "todos") {
            const productoCategoria = productos.find(producto => producto.categoria.id === e.currentTarget.id);
            tituloPrincipal.innerText = productoCategoria.categoria.nombre;
            const productosBoton = productos.filter(producto => producto.categoria.id === e.currentTarget.id);
            cargarProductos(productosBoton);
        } else {
            tituloPrincipal.innerText = "Todos los productos";
            cargarProductos(productos);
        }

    })
});

async function abrigos() {
    let reqData = await fetch(`http://localhost:5149/api/Producto/tipoabrigos`);
    let respJson = await reqData.json();
    abrigo.forEach(boton => boton.addEventListener("click", () => {
        try {
            const contenedorProductos = document.querySelector("#contenedor-productos");
            contenedorProductos.innerHTML = "";

            respJson.forEach(producto => {

                const div = document.createElement("div");
                div.classList.add("producto");
                div.innerHTML = /*html*/`
            <img class="producto-imagen" src="${producto.imagen}" alt="${producto.nombre}">
            <div class="producto-detalles">
                <h3 class="producto-titulo">${producto.nombre}</h3>
                <p class="producto-precio">$${producto.precio}</p>
                <button class="producto-agregar" id="${producto.id}">Agregar</button>
            </div>
        `;

                contenedorProductos.append(div);
            });
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }

        actualizarBotonesAgregar();
    }));
}
abrigos();

function actualizarBotonesAgregar() {
    botonesAgregar = document.querySelectorAll(".producto-agregar");

    botonesAgregar.forEach(boton => {
        boton.addEventListener("click", agregarAlCarrito);
    });
}

let productosEnCarrito;

let productosEnCarritoLS = localStorage.getItem("productos-en-carrito");

if (productosEnCarritoLS) {
    productosEnCarrito = JSON.parse(productosEnCarritoLS);
    actualizarNumerito();
} else {
    productosEnCarrito = [];
}

function agregarAlCarrito(e) {

    Toastify({
        text: "Producto agregado",
        duration: 3000,
        close: true,
        gravity: "top", // `top` or `bottom`
        position: "right", // `left`, `center` or `right`
        stopOnFocus: true, // Prevents dismissing of toast on hover
        style: {
            background: "linear-gradient(to right, #000, #aaa)",
            borderRadius: "2rem",
            textTransform: "uppercase",
            fontSize: ".75rem",
            color: "#fff"
        },
        offset: {
            x: '1.5rem', // horizontal axis - can be a number or a string indicating unity. eg: '2em'
            y: '1.5rem' // vertical axis - can be a number or a string indicating unity. eg: '2em'
        },
        onClick: function () { } // Callback after click
    }).showToast();

    const idBoton = e.currentTarget.id;
    const productoAgregado = productos.find(producto => producto.id === idBoton);

    if (productosEnCarrito.some(producto => producto.id === idBoton)) {
        const index = productosEnCarrito.findIndex(producto => producto.id === idBoton);
        productosEnCarrito[index].cantidad;
    } else {
        productoAgregado.cantidad = 1;
        productosEnCarrito.push(productoAgregado);
    }

    actualizarNumerito();

    localStorage.setItem("productos-en-carrito", JSON.stringify(productosEnCarrito));
}

function actualizarNumerito() {
    let nuevoNumerito = productosEnCarrito.reduce((acc, producto) => acc + producto.cantidad, 0);
    numerito.innerText = nuevoNumerito;
}








