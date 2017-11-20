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
INSERT INTO `__migrationhistory` VALUES ('201711201011287_InitialCreate','WeatherEntities.Migrations.Configuration','‹\0\0\0\0\0\0\íY\Ûn\ã6}/\Ð ôXd­\\PtØ»H¤0º¹ Nvû0\Ò\Ø!J‘*I6Š~YúIý…u—(ù–Ú¢X`!“œ3\Ã\á™\áó\×?.\"Nž@i&\Å\È;\ì{D C&\æ#/1³wï½¾þjxFò¹Xwd×¡¤\Ð#\ïÑ˜ø\Ø÷uðÕƒˆJj93ƒ@F>\r¥¸¿ÿ½p\àBxˆE\Èð&†EþÀŸc)ˆMBù…\ë|g¦)*¹¤\è˜0ò¾\05 \ÎÀ0\Ð9áŒ¢S\à3P!¤¡<¾\Ó05JŠù4\Æ\Êo—1\àº\å\Zrã«\å›\îcÿ\Ð\îÃ¯¨ \ÑFF[\åŽñ\Û\â;¹\×+‡®K=´´»N\Ý7ò\Æø\Ó#mE\Çc®\ì\"Ç³ƒô,Vj´\æöJ* c\ì¿=2N¸IŒ$FQ¾G®“Î‚Ÿ`y+1	\çuû\ÐBœk\àÐµ’1(³¼Ynõ$ôˆß”óÛ‚¥XM&\Û\ÓD˜£C\\¢rúÀ¡<þ\Úþ§F*ø(j ¼¦Æ€R:\Ú[º\ìÿ…6\äÆG.\è\âˆ¹yyø\é‘s¶€°\É-¸\Ã…ŒJ \Ã\Â\ÕZ\ï¿£øh¾¤OlžºªeC\Î	Á\à\éý\È\â,ù\ä}Fºs%£\É+¡tüþ–ª9Üƒì˜œ\ÊD-s†~\Å\ê•\\Ï‘¶§{>ú?\ãûu¢T¡\Í~ß²h{ô¤-\Ê\ÛG\Ï$\Ìy¹\Úe«An!Š­‘÷§´;…€E”{\äZ\áW~­¾÷\È4 úyz.\ÙüÑ¼œ¦\Þ\ÐÎ¼³kX‘\Û\ÖE\Ìo\Ö\'ZË€¥64\ã:\Ó\ß\ÜÌ™\É*c2Ž\Õ6L\Ãf1\Æ,.y\ß8þ\é,\ÓV™ù£‰w\àµcýJœ\ä$\ÈJ„1\Õ\rÝƒA„\ÍL l|RŽÕ’Æ„Ã„qs	‹)_auKf\Ãdm*\Ñ\Û3§ƒ°\Éc…ÿ7S›ó\Ê\Õ]ªhùi[†~Cî2%@5\ée‡aa:n,*óDç¹§\Í;SRZ¤Vün\Æ\á[Sººaù’\Ã-ˆ\ÚvœÜ»µ%]Q\Ýöýš¸*m®›\ë\àšHªkGDscÉ£<Ëª{ð³ö¡h3üž>cxA\ã¯žZß‘i\ÖtŒ\ßM·/È£\ÃtG]^Z[j\ÂK™Î¡5‹ª\Ñ\Òs¦´Á«–>P›\Å\Ça\ä,k1·‡W…²9Ý³*¸V,·\ß\r&•ESc*÷\ãŽ\"›ÒŠ£y\Èbi¿G9U\Å\ÍXò$ý\é©_:+\Ð\ëò\Ù\È\æU±]G©F]¤¡\ßò€“\Ð\';@ó\È6:\Ð2\0Ÿs¤Ef\ÙþT{%_\ç`³:´.ŸlŽ\Ð(B\ë@‰\Íñ\Ê¬¹©ž[­\Ç)-\ëx\Î\än¸y)Ù‡œO¿1µ\\\Þ^Rj/sz+wó<ºþ!\ÉI¬\Ù[N\Ë\'Ú¤z±œþ\Êv~~Ž9\Ã\rW+.¨`3\Ð&\ë÷¼oßµž£þ9OC¾\Ö!\ß\à}\è\ÍûUfº¶#Ý²gª?\Êp‰cZ\Í=óeC ­\ß(þ.¯¿\n„øm\ÒWZkºÿo;f«\åO]\àT÷l1#\ï·T\æ˜L~¾\Ï\ÅöÈ•\Âx?&û\ä÷—z(\ß\ì¡\à™š^¸;¯\Ã\Ûô\ÎNó±\ÛkÀN-xOüZ=÷¿¤\Ïv›šµmô²·‰\Î\îm¤ùƒÄƒ\Íh\Ü\ÓEö4Ø«ú\ë.ô¾F÷U»\ïºª&jƒV»«GþÚ­½9µ?õ!k5›Wö‚g\Ê51“w[KZ	ðÅ«‡ž(\Ãf408€\Ö\é£òg\Ê\\r=@8W‰‰ƒ[†\è7œhC`•þô¡ióð*N_I_bh&³·\ç•ø!a<,\í>\ïH\Ë=6¶ò{Ýž¥±÷û|Y\"]J±!P\î¾2%\Øû…#˜¾Sú»\Øv§\á\Ìi°,*\è~õ\Ñtûð”Ñ¹¢‘\Î1*yü‰£Å‡¿ˆ\r\åñ\0\0','6.2.0-61023');
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
