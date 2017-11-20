-- MySQL dump 10.13  Distrib 5.7.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: weather_test
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cities`
--

DROP TABLE IF EXISTS `cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cities` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Url_Code` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cities`
--

LOCK TABLES `cities` WRITE;
/*!40000 ALTER TABLE `cities` DISABLE KEYS */;
INSERT INTO `cities` VALUES (1,'Брянск','bryansk'),(2,'Клинцы','klintsy'),(3,'Навля','navlya'),(4,'Карачев','karachev'),(5,'Севск','sevsk'),(6,'Стародуб, Городской округ Стародуб','starodub'),(7,'Унеча','unecha'),(8,'Злынка','zlynka'),(9,'Мглин','mglin'),(10,'Сельцо, Городской округ Сельцо','seltso'),(11,'Фокино','fokino-bryansk-district'),(12,'Дятьково','dyatkovo'),(13,'Жуковка','zhukovka'),(14,'Новозыбков','novozibkov'),(15,'Почеп','pochep'),(16,'Сураж','suraj'),(17,'Трубчевск','trubchevsk'),(18,'Челюскин','cheljuskin'),(19,'Супонево','suponevo'),(20,'Локоть','lokot'),(21,'Москва','moscow'),(22,'Санкт-Петербург','saint-petersburg'),(23,'Екатеринбург','yekaterinburg'),(24,'Нижний Новгород','nizhny-novgorod'),(25,'Новосибирск','novosibirsk'),(26,'Уфа','ufa'),(27,'Ростов-на-Дону','rostov-na-donu'),(28,'Пермь','perm'),(29,'Самара','samara'),(30,'Казань','kazan'),(31,'Красноярск','krasnoyarsk'),(32,'Краснодар','krasnodar'),(33,'Челябинск','chelyabinsk'),(34,'Воронеж','voronezh'),(35,'Волгоград','volgograd'),(36,'Саратов','saratov'),(37,'Омск','omsk'),(38,'Тюмень','tyumen'),(39,'Тула','tula'),(40,'Ярославль','yaroslavl'),(41,'Пекин','beijing'),(42,'Бангкок','bangkok'),(43,'Тегеран','tehran'),(44,'Токио','tokyo'),(45,'Москва','moscow'),(46,'Дели','delhi'),(47,'Сеул','seoul'),(48,'Киншаса','kinshasa'),(49,'Дакка','dhaka'),(50,'Джакарта','jakarta'),(51,'Мехико','mexico'),(52,'Лондон','london'),(53,'Каир','cairo'),(54,'Лима','lima'),(55,'Богота','bogota'),(56,'Ханой','hanoi'),(57,'Каракас','caracas'),(58,'Багдад','baghdad'),(59,'Сантьяго','santiago'),(60,'Сингапур','singapore');
/*!40000 ALTER TABLE `cities` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-11-20 16:59:21
