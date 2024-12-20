-- Insertar un producto
CREATE FUNCTION insertar_producto(
p_nombre VARCHAR,
p_precio DOUBLE PRECISION,
p_cantidad INTEGER,
p_fecha_registrar DATE,
p_estado BOOLEAN
) RETURNS VOID AS $$
BEGIN
INSERT INTO schemasye."tc_producto" (nombre, precio, cantidad, fecha_registrar, estado)
VALUES (p_nombre, p_precio, p_cantidad, p_fecha_registrar, p_estado);
END;
$$ LANGUAGE plpgsql;

-- Obtener todos los productos
CREATE FUNCTION obtener_productos()
RETURNS TABLE (
    idproducto INT,
    nombre VARCHAR,
    precio DOUBLE PRECISION,
    cantidad INT,
    fecha_registrar DATE,
    estado BOOLEAN
) AS $$
BEGIN
    RETURN QUERY 
    SELECT p.idproducto, p.nombre, p.precio, p.cantidad, p.fecha_registrar, p.estado
    FROM schemasye."tc_producto" p
    WHERE p.estado = TRUE
    ORDER BY p.idproducto ASC;
END;
$$ LANGUAGE plpgsql;

-- Obtener producto por ID
CREATE FUNCTION obtener_producto_por_id(p_idproducto INT)
RETURNS TABLE (
    idproducto INT,
    nombre VARCHAR,
    precio DOUBLE PRECISION,
    cantidad INT,
    fecha_registrar DATE,
    estado BOOLEAN
) AS $$
BEGIN
    RETURN QUERY 
    SELECT p.idproducto, p.nombre, p.precio, p.cantidad, p.fecha_registrar, p.estado
    FROM schemasye."tc_producto" p
    WHERE p.idproducto = p_idproducto;
END;
$$ LANGUAGE plpgsql;

-- Actualizar un producto
CREATE FUNCTION actualizar_producto(
    p_idproducto INT,
    p_nombre VARCHAR,
    p_precio DOUBLE PRECISION,
    p_cantidad INT,
    p_fecha_registrar DATE,
    p_estado BOOLEAN
) RETURNS VOID AS $$
BEGIN
    UPDATE schemasye."tc_producto"
    SET 
        nombre = p_nombre,
        precio = p_precio,
        cantidad = p_cantidad,
        fecha_registrar = p_fecha_registrar,
        estado = p_estado
    WHERE idproducto = p_idproducto;
END;
$$ LANGUAGE plpgsql;

-- Eliminar producto (eliminación lógica)
CREATE FUNCTION eliminar_producto(p_idproducto INT)
RETURNS VOID AS $$
BEGIN
    UPDATE schemasye."tc_producto"
    SET estado = FALSE
    WHERE idproducto = p_idproducto;
END;
$$ LANGUAGE plpgsql;