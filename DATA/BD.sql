CREATE DATABASE IF NOT EXISTS dados;
USE dados;

CREATE TABLE IF NOT EXISTS empresa(
	id_emp INTEGER PRIMARY KEY AUTO_INCREMENT,
    razao_social_emp VARCHAR(250) NOT NULL,
    nome_fantasia_emp VARCHAR(250) NOT NULL,
    cnpj_emp VARCHAR(14) UNIQUE NOT NULL,
    insc_estadual_emp VARCHAR(20),
    telefone_emp VARCHAR(11) NOT NULL,
    email_emp VARCHAR(100) NOT NULL,
    cidade_emp VARCHAR(100) NOT NULL,
    estado_emp VARCHAR(2) NOT NULL,
    cep_emp VARCHAR(8) NOT NULL,
    dt_cadastro_emp DATETIME
);

ALTER TABLE empresa CHANGE estado_emp estado_emp VARCHAR(2) NOT NULL;

SELECT * FROM empresa;

INSERT INTO empresa( razao_social_emp, nome_fantasia_emp, cnpj_emp, insc_estadual_emp, 
telefone_emp, email_emp, cidade_emp, estado_emp, cep_emp, dt_cadastro_emp) VALUES
('VerdeVivo', 'VerdeVivo Comércio e Serviços Ambientais Ltda.', '98765432000155', '987654321224', '34413906', 'verdevivo@gmail.com', 'Belo Horizonte', 'MG', '30110002', '2025-09-24 16:30:00.500'),
('AlphaPrime', 'AlphaPrime Consultoria Empresarial EIRELI', '45678912000133', NULL, '34212548', 'alpha@gmail.com', 'Brasília', 'DF', '70040010', '2025-09-25 20:30:00.500'),
('BellaArte', 'BellaArte Indústria e Comércio de Decoração Ltda.', '23456789000177', '456789123336', '34123555', 'bellaarte@gmail.com', 'Brasília', 'DF', '70040010', '2025-09-26 12:30:00.500');
