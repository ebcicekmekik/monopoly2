USE MonopolyDB;

-- Günlük skorlar için test verileri
INSERT INTO Oyunlar (Email, Skor, Tarih, GunlukSkor, AylikSkor, YillikSkor)
VALUES 
('test1@test.com', 1500, GETDATE(), 1500, NULL, NULL),
('test2@test.com', 2000, GETDATE(), 2000, NULL, NULL),
('test3@test.com', 1800, GETDATE(), 1800, NULL, NULL);

-- Aylık skorlar için test verileri
INSERT INTO Oyunlar (Email, Skor, Tarih, GunlukSkor, AylikSkor, YillikSkor)
VALUES 
('test4@test.com', 2500, GETDATE(), NULL, 2500, NULL),
('test5@test.com', 3000, GETDATE(), NULL, 3000, NULL),
('test6@test.com', 2800, GETDATE(), NULL, 2800, NULL);

-- Yıllık skorlar için test verileri
INSERT INTO Oyunlar (Email, Skor, Tarih, GunlukSkor, AylikSkor, YillikSkor)
VALUES 
('test7@test.com', 3500, GETDATE(), NULL, NULL, 3500),
('test8@test.com', 4000, GETDATE(), NULL, NULL, 4000),
('test9@test.com', 3800, GETDATE(), NULL, NULL, 3800); 