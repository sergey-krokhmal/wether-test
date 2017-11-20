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
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201711201011287_InitialCreate','WeatherEntities.Migrations.Configuration','�\0\0\0\0\0\0\�Y\�n\�6}/\� �Xd�\\PtػH��0�� Nv�0\�\�!J�*I6�~Y�I��u�(��ڢX`!��3\�\�\��\�?.\"N�@i&\�\�;\�{D C&\�#/1�wｏ��jxF�Xwdס�\�#\�ј�\��u�Ճ�Jj93�@F>\r�����p\�Bx�E\��&�E����c)�MB���\�|g�)*��\�0�\05��\��0\�9ጢS\�3�P!���<�\�05J��4\�\�o�1\�\�\Zr㏫\�\�c�\�\�ï� \�FF[\��\�\�;�\�+��K=���N\�7�\��\�#mE\�c�\�\"ǳ��,Vj��\��J* c\�=2N�I�$FQ�G��΂�`y+1	\�u�\�B�k\�е�1(���Yn�$�ߔ�ۂ�XM&\�\�D��C�\\�r���<�\���F*�(j ��ƀR:\�[�\���6\�ƍG.\�\���yy�\�s���\�-�\���J�\�\�\�Z\����h��Ol���eC\�	�\�\��\�\�,�\�}F�s%�\�+�t����9܃옜\�D-s�~\�\�\\ϑ��{>�?\��u��T�\�~߲h{���-\�\�G\�$\�y�\�e�An!������;��E�{\�Z\�W~���\�4��yz.\��Ѽ��\�\�μ�kX�\�\�E\�o\�\'Zˀ�64\�:\�\�\�̙\�*c2�\�6�L\�f1\�,.y\�8�\�,\�V����w\�c�J�\�$\�J�1\�\r݃A�\�L�l|R�ՒƄÄqs	�)_auKf\�dm*\�\�3���\�c��7S��\�\�]�h�i�[�~�C2%@5\�e�aa:n,*�D繧\�;SRZ�V�n\�\�[S��a��\�-�\�v�ܻ�%]Q\�����*m��\�\��H��kGDscɣ<˪{���h3��>cxA\���Zߑ��i\�t�\�M�/ȣ\�tG]^Z[j\�K�Ρ5��\�\�s�����>P�\�\�a\�,k1��W��9ݳ*�V,�\�\r&�ESc*��\�\"�Ҋ�y\�bi�G9U\�\�X�$�\�_:+\�\��\�\�\�U�]G�F]��\��\�\';@�\�6:\�2\0�s�Ef\��T{%_\�`�:�.��l�\�(B\�@��\��\�����[�\�)-\�x\�\�n�y)ه�O�1��\\\�^Rj/sz+w�<��!\�I�\�[N\�\'ڤz���\�v~�~�9\�\rW+.�`3\�&\���oߵ���9OC�\�!\�\�}\�\��Uf��#ݲg�?\�p��cZ\�=�eC��\�(�.��\n��m\�W�Zk��o;f�\�O]\�T�l1#\�T\�L~�\�\��ȕ\�x?&�\���z(\�\�\���^�;�\�\��\�N�\�k�N-xO��Z=���\�v���m����\�\�m���ă\�h\�\�E�4ث�\�.��F�U�\��&j�V��G��ڭ��9�?�!k5�W��g\�51�w[KZ	�ū��(\�f408�\�\��g\�\\r=@8W���[�\�7�hC`����i��*N_I_bh&��\��!a<,\�>\�H\�=6��{ݞ����|Y\"]J�!P\�2%\���#��S��\�v�\�\�i�,*\�~��\�t��ѹ��\�1*y���Ň���\r\��\0\0','6.2.0-61023');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
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
