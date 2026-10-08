var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

var empresaData = new
{
    id = 1,
    codigo = "E001",
    nombre = "Abarrotes La Esquina",
    eslogan = "Tu despensa de siempre, ahora a un clic",
    direccion = "Jr. Los Olivos 245",
    telefono = "+51 955 321 654",
    horarioAtencion = "Lunes a domingo, 07:00 - 22:00",
    valores = new[]
    {
        new { titulo = "Frescura diaria", texto = "Frutas y lácteos que llegan cada mañana." },
        new { titulo = "Precios online", texto = "Ofertas exclusivas que se actualizan cada semana." },
        new { titulo = "Delivery rápido", texto = "Te lo llevamos a casa o lo recoges en tienda." },
        new { titulo = "Atención de barrio", texto = "Un equipo que te conoce y te recomienda." }
    }
};

var categoriasData = new[]
{
    new { id = "abarrotes", nombre = "Abarrotes", descripcion = "Arroz, aceite, fideos y conservas para tu despensa." },
    new { id = "lacteos", nombre = "Lácteos", descripcion = "Leches, yogures y quesos de las mejores marcas." },
    new { id = "frutas", nombre = "Frutas", descripcion = "Fruta fresca seleccionada cada día." },
    new { id = "limpieza", nombre = "Limpieza", descripcion = "Detergentes, lejía y lavavajillas para el hogar." }
};

var promocionesData = new[]
{
    new { id = 1, codigo = "PR001", titulo = "Semana de la despensa", descripcion = "Precios rebajados en arroz, aceite y conservas.", categoria = "abarrotes", etiqueta = "Hasta 15% menos", activa = true },
    new { id = 2, codigo = "PR002", titulo = "Packs lácteos familiares", descripcion = "Ahorra llevando tripacks y sixpacks de leche.", categoria = "lacteos", etiqueta = "Packs con descuento", activa = true },
    new { id = 3, codigo = "PR003", titulo = "Fruta de temporada", descripcion = "Mandarina y plátano a precio especial.", categoria = "frutas", etiqueta = "Oferta de la semana", activa = true },
    new { id = 4, codigo = "PR004", titulo = "Limpieza del hogar", descripcion = "Detergente en oferta para toda la familia.", categoria = "limpieza", etiqueta = "Hasta 21% menos", activa = true },
    new { id = 5, codigo = "PR005", titulo = "Promo Fiestas Patrias", descripcion = "Campaña finalizada.", categoria = "abarrotes", etiqueta = "Finalizada", activa = false }
};

var entregasData = new[]
{
    new { id = 1, nombre = "Recojo en tienda", descripcion = "Recoge tu pedido en 30 minutos en Jr. Los Olivos 245.", costo = 0, requiereDireccion = false },
    new { id = 2, nombre = "Delivery estándar", descripcion = "Entrega en el día dentro del distrito.", costo = 5, requiereDireccion = true },
    new { id = 3, nombre = "Delivery express", descripcion = "Entrega en 60 minutos.", costo = 8, requiereDireccion = true }
};

app.MapGet("/", () => Results.Ok(new
{
    empresa = empresaData,
    categorias = categoriasData,
    promociones = promocionesData,
    entregas = entregasData
}));

app.MapGet("/api/empresa", () => Results.Ok(empresaData));

var productos = new[]
{
    new { id = 1, codigo = "P001", nombre = "Arroz superior", presentacion = "Bolsa 5 kg", categoria = "abarrotes", precio = 18.5, antes = (double?)21.9, img = "https://metroio.vtexassets.com/arquivos/ids/453498/ARROZ-SUPERIOR-X-5KG-CUISINE-CO-1-351639056.jpg?v=638285249186930000" },
    new { id = 2, codigo = "P002", nombre = "Aceite vegetal", presentacion = "Botella 1 L", categoria = "abarrotes", precio = 7.9, antes = (double?)9.5, img = "https://mercury.vtexassets.com/arquivos/ids/8788179-800-800?v=637957648769000000&width=800&height=800&aspect=true" },
    new { id = 3, codigo = "P003", nombre = "Fideos spaghetti", presentacion = "Bolsa 500 g", categoria = "abarrotes", precio = 3.2, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRvqRdX5x-NFM1n1KLBezaoXXaijRO0Qpub1lPHgUDgfw&s=10" },
    new { id = 4, codigo = "P004", nombre = "Azúcar rubia", presentacion = "Bolsa 1 kg", categoria = "abarrotes", precio = 4.1, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/30578637-512-512/20283176.jpg" },
    new { id = 5, codigo = "P005", nombre = "Leche evaporada", presentacion = "Lata 400 g", categoria = "lacteos", precio = 3.8, antes = (double?)null, img = "https://www.alem.tufacel.com/assets/uploads/8434c32ff1fc71a679152bfa511a5f29.jpg" },
    new { id = 6, codigo = "P006", nombre = "Manzana Delicia", presentacion = "Malla 1 kg", categoria = "frutas", precio = 4.5, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB1kwqYLGrWcVKYuHvDuyRLYAk_4IXnUhGpLKUKgvckoMSGgv0_cIg7jM&s=10" },
    new { id = 7, codigo = "P007", nombre = "Plátano de seda", presentacion = "Kilo", categoria = "frutas", precio = 3.0, antes = (double?)3.8, img = "https://plazavea.vteximg.com.br/arquivos/ids/29450552-450-450/772631.jpg?v=639167417972170000" },
    new { id = 8, codigo = "P008", nombre = "Naranja de jugo", presentacion = "Malla 1 kg", categoria = "frutas", precio = 2.8, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQj9q6ObAqeARTmvV-PuFROJaJgmEEVuc9Ed7US3BFc2Q&s" },
    new { id = 9, codigo = "P009", nombre = "Mandarina", presentacion = "Kilo", categoria = "frutas", precio = 3.5, antes = (double?)4.5, img = "https://metroio.vtexassets.com/arquivos/ids/542237/Mandarina-Costa-x-kg-3-23864.jpg?v=638605821780900000" },
    new { id = 10, codigo = "P010", nombre = "Detergente", presentacion = "Bolsa 2 kg", categoria = "limpieza", precio = 14.9, antes = (double?)18.9, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdWYwQRBiER9sk_DbZSmAHzr9airXUBQyA_rn1EnbbNnXSO4iatqWd7xI&s=10" },
    new { id = 11, codigo = "P011", nombre = "Lavavajilla", presentacion = "Crema 500 g", categoria = "limpieza", precio = 6.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXYJ2abgyDe2t-gCXFqHq0PCDGxYWAcm_ScakQvUCArdp2R73Qte0sEWYm&s=10" },
    new { id = 12, codigo = "P012", nombre = "Lejía", presentacion = "Botella 1 L", categoria = "limpieza", precio = 5.5, antes = (double?)null, img = "https://dojiw2m9tvv09.cloudfront.net/53648/product/lejia-original-x-1-litro-9428-default-13278.jpg" },
    new { id = 13, codigo = "P013", nombre = "Queso fresco", presentacion = "Paquete 250 g", categoria = "lacteos", precio = 9.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0ozVzVPV80BZSZcexjh3PoYPn6opgmmDP1Kj8DMshRQ&s=10" },
    new { id = 14, codigo = "P014", nombre = "Yogurt natural", presentacion = "Botella 1 L", categoria = "lacteos", precio = 7.5, antes = (double?)8.9, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEWtwKReMFPFYuE-Z14CcOW_KN-Xt_NLZ45L1ngAPQqA&s" },
    new { id = 15, codigo = "P015", nombre = "Atún en aceite", presentacion = "Lata 170 g", categoria = "abarrotes", precio = 5.2, antes = (double?)6.5, img = "https://miamarket.pe/assets/uploads/283f5b9f8ebbb33d571e1a5922e5928b.jpg" },
    new { id = 16, codigo = "P016", nombre = "Leche entera UHT Gloria", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 6.5, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0r56u8Vd5JOl4IoWSjdbymKy3sDLcJC0xkv6FKssUNg&s=10" },
    new { id = 17, codigo = "P017", nombre = "Leche UHT Laive", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 4.8, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081448-1000-1000/990763.jpg?v=639177601244300000" },
    new { id = 18, codigo = "P018", nombre = "Leche evaporada Bella Holandesa", presentacion = "Lata 405 g", categoria = "lacteos", precio = 3.4, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKu_81YkWQKKMrauS1k9n1vT4rIV7R9av5r7pPyYgcPw&s=10" },
    new { id = 19, codigo = "P019", nombre = "Leche pasteurizada Danlac", presentacion = "Botella 900 ml", categoria = "lacteos", precio = 8.1, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081450-1000-1000/28547.jpg?v=639177601309630000" },
    new { id = 20, codigo = "P020", nombre = "Leche UHT Vigor", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 5.3, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSay8iUk-a_Yp-cgOW6USxZ4-dpAwR-N3J7Nxg51rp9cQ&s=10" },
    new { id = 21, codigo = "P021", nombre = "Leche UHT Milkito", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 4.8, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081687-418-418/20571494.jpg" },
    new { id = 22, codigo = "P022", nombre = "Leche sabor chocolate Gloria", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 7.2, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBx1V7m6kRPRGker-lluqibc6_NQq1-C9A3RYrjav0sw8uwPgLGsm9Fn4&s=10" },
    new { id = 23, codigo = "P023", nombre = "Pack x6 leche evaporada Gloria", presentacion = "Entera", categoria = "lacteos", precio = 24.9, antes = (double?)null, img = "https://wongfood.vtexassets.com/arquivos/ids/778705-800-auto?v=638880610068930000&width=800&height=auto&aspect=true" },
    new { id = 24, codigo = "P024", nombre = "Sixpack leche reconstituida Gloria", presentacion = "Lata 390 g", categoria = "lacteos", precio = 21.8, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081592-418-418/20402655.jpg" },
    new { id = 25, codigo = "P025", nombre = "Leche ultrafiltrada sin lactosa Gloria Zero Lacto", presentacion = "Lata 390 g", categoria = "lacteos", precio = 4.5, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVA2A-kBC9A1CqMCIpkbLcI8Kgx2AKL3RkYW7yS--nww&s=10" },
    new { id = 26, codigo = "P026", nombre = "Leche light Laive sin lactosa", presentacion = "Botella 390 g", categoria = "lacteos", precio = 4.9, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081520-450-450/20358055.jpg?v=639177603279630000" },
    new { id = 27, codigo = "P027", nombre = "Leche reconstituida Gloria", presentacion = "Lata 390 g", categoria = "lacteos", precio = 4.5, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081589-418-418/20402646.jpg" },
    new { id = 28, codigo = "P028", nombre = "Leche reconstituida Gloria Light", presentacion = "Lata 390 g", categoria = "lacteos", precio = 4.5, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081596-418-418/20402653.jpg" },
    new { id = 29, codigo = "P029", nombre = "Leche concentrada sin lactosa Laive", presentacion = "Botella 390 g", categoria = "lacteos", precio = 4.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaXu09EPPnzTVF6z_V1DLNpBYWDq0b6ZHu0wWbAa1OHeteR7MeVyDlxaw&s=10" },
    new { id = 30, codigo = "P030", nombre = "Leche para diluir Laive", presentacion = "Botella 390 g", categoria = "lacteos", precio = 4.7, antes = (double?)null, img = "https://res.cloudinary.com/riqra/image/upload/v1755799255/sellers/10/wspgcykextielprcst4v.png" },
    new { id = 31, codigo = "P031", nombre = "Leche evaporada light Cuisine & Co", presentacion = "Lata 410 g", categoria = "lacteos", precio = 4.2, antes = (double?)null, img = "https://metroio.vtexassets.com/arquivos/ids/559577-800-auto?v=638690386184000000&width=800&height=auto&aspect=true" },
    new { id = 32, codigo = "P032", nombre = "Leche UHT Gloria Light", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 6.5, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081438-450-450/665063.jpg?v=639177600937400000" },
    new { id = 33, codigo = "P033", nombre = "Leche UHT sin lactosa Gloria Zero Lacto", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 6.5, antes = (double?)null, img = "https://vegaperu.vtexassets.com/arquivos/ids/176584/134197.jpg?v=639175023189130000" },
    new { id = 34, codigo = "P034", nombre = "Leche entera UHT Laive", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 5.9, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081548-418-418/20393011.jpg" },
    new { id = 35, codigo = "P035", nombre = "Leche descremada UHT Laive Sbelt", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 5.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRT9SltLjzgoHgyw92ISpahmodk0E7-OfX0Ma4TB8byzuoqMc-X-eIR41KX&s=10" },
    new { id = 36, codigo = "P036", nombre = "Leche semidescremada UHT Laive sin lactosa", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 5.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQN6rL8PaSOJ_90r9MNGMjoOeCDHozhRkqEcVVnbnOqvA&s=10" },
    new { id = 37, codigo = "P037", nombre = "Leche entera UHT Gloria", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 4.9, antes = (double?)null, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081458-450-450/20198432.jpg?v=639177601541630000" },
    new { id = 38, codigo = "P038", nombre = "Leche parcialmente descremada Gloria Light", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 4.7, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1oA-7pqVKlU3xS9MF8huzb-9-1GEMXQzR4tovbbh8-A&s=10" },
    new { id = 39, codigo = "P039", nombre = "Leche UHT sin lactosa Vigor", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 5.5, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0kxLc2VnEjI8ZRDKRtrhuauSme-oiiyOJHuC2zn5umMyqDIkrciFYTPw&s=10" },
    new { id = 40, codigo = "P040", nombre = "Leche deslactosada Danlac Light", presentacion = "Botella 900 ml", categoria = "lacteos", precio = 9.0, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4l5uPJuamZOOmrO-V1tG7OXgDbGgVsQOvBqU-S4_aGQ&s" },
    new { id = 41, codigo = "P041", nombre = "Leche UHT entera Cuisine & Co", presentacion = "Caja 1 L", categoria = "lacteos", precio = 5.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxxiBvc565IjYXoSq1iwQwz7ufN-KYMAnszjaifCiHQ8EN0WH64iFaqAGh&s=10" },
    new { id = 42, codigo = "P042", nombre = "Leche en polvo Gloria", presentacion = "Bolsa 96 g", categoria = "lacteos", precio = 5.7, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0cHoyah68xKlMleMKx5OQFwyJ_iyWPC0TGPLxuqCYcGNPDjp860ZV7k54&s=10" },
    new { id = 43, codigo = "P043", nombre = "Bebida láctea sabor chocolate Bonlé", presentacion = "Bolsa 800 ml", categoria = "lacteos", precio = 3.6, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkM2gq58g_HmSjtgWA1UqKiBmgjDzjwvhTpfYqZBJSyQ&s=10" },
    new { id = 44, codigo = "P044", nombre = "Leche chocolatada Gloria", presentacion = "Bolsa 900 ml", categoria = "lacteos", precio = 6.4, antes = (double?)null, img = "https://assets.bo-management.cord.pe/public/images/b472a031-1434-4796-926f-ff954905ce59-20198430_0.jpeg" },
    new { id = 45, codigo = "P045", nombre = "Tripack leche entera UHT Gloria", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 16.2, antes = (double?)18.0, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081441-450-450/929548.jpg?v=639177601042600000" },
    new { id = 46, codigo = "P046", nombre = "Tripack leche UHT Gloria Light", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 16.5, antes = (double?)null, img = "https://metroio.vtexassets.com/arquivos/ids/607567/363768-01-22449.jpg?v=639130014509030000" },
    new { id = 47, codigo = "P047", nombre = "Fourpack leche entera UHT Laive", presentacion = "Caja 946 ml", categoria = "lacteos", precio = 20.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQouZqgN4lQdtD0JhBb-HWdj30yB925O1MzJIQBD5uYqBjghNPVzxw2XcA&s=10" },
    new { id = 48, codigo = "P048", nombre = "Sixpack leche Gloria Niños", presentacion = "Lata 390 g", categoria = "lacteos", precio = 22.9, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT-ZdWQtCQMc5QfgN8vIqMCqO5Q5ItVMgI-Y--5_pEdxTDTsoReyw1B28sH&s=10" },
    new { id = 49, codigo = "P049", nombre = "Sixpack leche light Laive sin lactosa", presentacion = "Botella 390 g", categoria = "lacteos", precio = 21.9, antes = (double?)25.9, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrfOq1NDQ0cSWz_9nu6xQoOa6vAU4NqRo4OefidkWD608oLlk06DFUi_h7&s=10" },
    new { id = 50, codigo = "P050", nombre = "Pack x6 leche reconstituida entera Gloria", presentacion = "Lata 390 g", categoria = "lacteos", precio = 22.9, antes = (double?)24.6, img = "https://plazavea.vteximg.com.br/arquivos/ids/35081592-450-450/20402655.jpg?v=639177613125270000" },
    new { id = 51, codigo = "P051", nombre = "Pack x6 mezcla láctea Laive sin lactosa", presentacion = "480 g", categoria = "lacteos", precio = 23.4, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwG7yt4ORnyqltoxjFEhdqH2RCJFtJPqdeU3lHnC8xCg&s" },
    new { id = 52, codigo = "P052", nombre = "Sixpack mezcla láctea Bonlé Familiar", presentacion = "Caja 480 g", categoria = "lacteos", precio = 19.7, antes = (double?)null, img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRpQ1Taybv_HZck3dOQOnFBQ6DIQE1p7ealAoa3YHQVgA&s" }
};

var pedidos = new List<object>();

app.MapGet("/api/productos", () => Results.Ok(productos));

app.MapGet("/api/productos/{id:int}", (int id) =>
{
    var producto = productos.FirstOrDefault(p => p.id == id);

    return producto is not null
        ? Results.Ok(producto)
        : Results.NotFound(new { mensaje = "Producto no encontrado" });
});

app.MapGet("/api/categorias", () => Results.Ok(categoriasData));

app.MapGet("/api/promociones", () => Results.Ok(promocionesData));

app.MapGet("/api/entregas", () => Results.Ok(entregasData));

app.MapGet("/api/pedidos", () => Results.Ok(pedidos));

app.MapPost("/api/pedidos", (PedidoRequest pedido) =>
{
    if (pedido.Productos is null || pedido.Productos.Count == 0)
    {
        return Results.BadRequest(new { mensaje = "El pedido debe contener al menos un producto." });
    }

    if (string.IsNullOrWhiteSpace(pedido.Cliente))
    {
        return Results.BadRequest(new { mensaje = "El nombre del cliente es obligatorio." });
    }

    var entrega = pedido.EntregaId switch
    {
        1 => new { id = 1, nombre = "Recojo en tienda", costo = 0, requiereDireccion = false },
        2 => new { id = 2, nombre = "Delivery estándar", costo = 5, requiereDireccion = true },
        3 => new { id = 3, nombre = "Delivery express", costo = 8, requiereDireccion = true },
        _ => null
    };

    if (entrega is null)
    {
        return Results.BadRequest(new { mensaje = "El método de entrega no es válido." });
    }

    if (entrega.requiereDireccion && string.IsNullOrWhiteSpace(pedido.Direccion))
    {
        return Results.BadRequest(new { mensaje = "La dirección es obligatoria para el delivery." });
    }

    var detalle = new List<object>();
    double subtotal = 0;

    foreach (var item in pedido.Productos)
    {
        var producto = productos.FirstOrDefault(p => p.id == item.ProductoId);

        if (producto is null)
        {
            return Results.BadRequest(new { mensaje = $"El producto con ID {item.ProductoId} no existe." });
        }

        if (item.Cantidad <= 0)
        {
            return Results.BadRequest(new { mensaje = "La cantidad debe ser mayor que cero." });
        }

        var importe = producto.precio * item.Cantidad;
        subtotal += importe;

        detalle.Add(new
        {
            productoId = producto.id,
            codigo = producto.codigo,
            nombre = producto.nombre,
            precio = producto.precio,
            cantidad = item.Cantidad,
            importe
        });
    }

    var nuevoPedido = new
    {
        id = pedidos.Count + 1,
        codigo = $"PED{pedidos.Count + 1:000}",
        cliente = pedido.Cliente,
        telefono = pedido.Telefono,
        direccion = pedido.Direccion,
        entrega = entrega.nombre,
        entregaId = entrega.id,
        costoEntrega = entrega.costo,
        productos = detalle,
        subtotal,
        total = subtotal + entrega.costo,
        estado = "Pendiente",
        fecha = DateTime.Now
    };

    pedidos.Add(nuevoPedido);

    return Results.Created($"/api/pedidos/{pedidos.Count}", nuevoPedido);
});

app.MapGet("/api/pedidos/{id:int}", (int id) =>
{
    var pedido = pedidos.FirstOrDefault(p =>
        (int)p.GetType().GetProperty("id")!.GetValue(p)! == id);

    return pedido is not null
        ? Results.Ok(pedido)
        : Results.NotFound(new { mensaje = "Pedido no encontrado" });
});

app.Run($"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT") ?? "10000"}");

public record PedidoRequest(
    string Cliente,
    string? Telefono,
    string? Direccion,
    int EntregaId,
    List<PedidoProductoRequest> Productos
);

public record PedidoProductoRequest(
    int ProductoId,
    int Cantidad
);
