CREATE TABLE Repartidor (
    id_repartidor INTEGER PRIMARY KEY,
    nombre VARCHAR(120) NOT NULL,
    email VARCHAR(160) NULL
);

CREATE TABLE Zonas (
    id_zona INTEGER PRIMARY KEY,
    nombre_zona VARCHAR(80) NOT NULL,
    tarifa_por_kg DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Envios (
    id_envio INTEGER PRIMARY KEY,
    id_repartidor INTEGER NOT NULL,
    id_zona INTEGER NOT NULL,
    peso_kg DECIMAL(10, 2) NOT NULL,
    fecha_envio DATE NOT NULL,
    CONSTRAINT FK_Envios_Repartidor FOREIGN KEY (id_repartidor) REFERENCES Repartidor(id_repartidor),
    CONSTRAINT FK_Envios_Zonas FOREIGN KEY (id_zona) REFERENCES Zonas(id_zona)
);

INSERT INTO Repartidor (id_repartidor, nombre, email) VALUES
(1, 'Andrés Hidalgo', 'andres.hidalgo@logistica.com'),
(2, 'Camila Torres', 'camila.torres@logistica.com'),
(3, 'Luis Andrade', 'luis.andrade@logistica.com'),
(4, 'Daniela Molina', 'daniela.molina@logistica.com');

INSERT INTO Zonas (id_zona, nombre_zona, tarifa_por_kg) VALUES
(1, 'Norte', 1.50),
(2, 'Sur', 2.00),
(3, 'Centro', 1.25),
(4, 'Valle', 1.80);

INSERT INTO Envios (id_envio, id_repartidor, id_zona, peso_kg, fecha_envio) VALUES
(1, 1, 1, 5.00, '2025-05-02'),
(2, 1, 1, 6.00, '2025-05-05'),
(3, 1, 1, 7.00, '2025-05-09'),
(4, 1, 1, 8.00, '2025-05-12'),
(5, 1, 1, 6.00, '2025-05-25'),
(6, 2, 2, 4.00, '2025-05-03'),
(7, 2, 2, 6.00, '2025-05-16'),
(8, 2, 2, 8.00, '2025-05-28'),
(9, 3, 3, 10.00, '2025-06-02'),
(10, 4, 1, 3.50, '2025-05-06'),
(11, 4, 2, 5.25, '2025-05-15'),
(12, 4, 4, 4.00, '2025-05-21'),
(13, 4, 3, 2.75, '2025-04-26');
