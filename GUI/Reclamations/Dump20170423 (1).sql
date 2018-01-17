-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: bdeasymission
-- ------------------------------------------------------
-- Server version	5.6.26-log

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
-- Table structure for table `candidature`
--

DROP TABLE IF EXISTS `candidature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `candidature` (
  `idCandidature` int(11) NOT NULL AUTO_INCREMENT,
  `cv` varchar(255) DEFAULT NULL,
  `dateSubmit` datetime DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `user_idUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idCandidature`),
  KEY `FKqnf2cjc5d6nflh9ugu76y7f3s` (`user_idUser`),
  CONSTRAINT `FKqnf2cjc5d6nflh9ugu76y7f3s` FOREIGN KEY (`user_idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidature`
--

LOCK TABLES `candidature` WRITE;
/*!40000 ALTER TABLE `candidature` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidature` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `forum`
--

DROP TABLE IF EXISTS `forum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `forum` (
  `idForum` int(11) NOT NULL AUTO_INCREMENT,
  `nomForum` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idForum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `forum`
--

LOCK TABLES `forum` WRITE;
/*!40000 ALTER TABLE `forum` DISABLE KEYS */;
/*!40000 ALTER TABLE `forum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `idPayment` int(11) NOT NULL AUTO_INCREMENT,
  `datePayment` datetime DEFAULT NULL,
  `valeur` float DEFAULT NULL,
  `user_idUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPayment`),
  KEY `FKtbn2noipxylxg6vx9wk0xuec1` (`user_idUser`),
  CONSTRAINT `FKtbn2noipxylxg6vx9wk0xuec1` FOREIGN KEY (`user_idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `promotion`
--

DROP TABLE IF EXISTS `promotion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `promotion` (
  `idPromotion` int(11) NOT NULL AUTO_INCREMENT,
  `dateDebut` datetime DEFAULT NULL,
  `dateFin` datetime DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `user_idUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPromotion`),
  KEY `FKnq9xfo1dq6aylhijt5828r9dk` (`user_idUser`),
  CONSTRAINT `FKnq9xfo1dq6aylhijt5828r9dk` FOREIGN KEY (`user_idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promotion`
--

LOCK TABLES `promotion` WRITE;
/*!40000 ALTER TABLE `promotion` DISABLE KEYS */;
/*!40000 ALTER TABLE `promotion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reclamation`
--

DROP TABLE IF EXISTS `reclamation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reclamation` (
  `idReclamtion` int(11) NOT NULL AUTO_INCREMENT,
  `dateSubmit` datetime DEFAULT NULL,
  `sujet` varchar(255) DEFAULT NULL,
  `user_idUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idReclamtion`),
  KEY `FKkkykscqnjm68fd039vxudbq0f` (`user_idUser`),
  CONSTRAINT `FKkkykscqnjm68fd039vxudbq0f` FOREIGN KEY (`user_idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reclamation`
--

LOCK TABLES `reclamation` WRITE;
/*!40000 ALTER TABLE `reclamation` DISABLE KEYS */;
/*!40000 ALTER TABLE `reclamation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `service` (
  `idService` int(11) NOT NULL AUTO_INCREMENT,
  `categorieService` varchar(255) DEFAULT NULL,
  `nomService` varchar(255) DEFAULT NULL,
  `payment_idPayment` int(11) DEFAULT NULL,
  `promotion_idPromotion` int(11) DEFAULT NULL,
  `user_idUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idService`),
  KEY `FK77sebv8qwsg71t546s2bpamf2` (`payment_idPayment`),
  KEY `FK7s1gf29grmmefqi6husjmmta9` (`promotion_idPromotion`),
  KEY `FKmpi7cc7kgfta4euxfipq5g37t` (`user_idUser`),
  CONSTRAINT `FK77sebv8qwsg71t546s2bpamf2` FOREIGN KEY (`payment_idPayment`) REFERENCES `payment` (`idPayment`),
  CONSTRAINT `FK7s1gf29grmmefqi6husjmmta9` FOREIGN KEY (`promotion_idPromotion`) REFERENCES `promotion` (`idPromotion`),
  CONSTRAINT `FKmpi7cc7kgfta4euxfipq5g37t` FOREIGN KEY (`user_idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sujet`
--

DROP TABLE IF EXISTS `sujet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sujet` (
  `idSujet` int(11) NOT NULL AUTO_INCREMENT,
  `dateSujet` datetime DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `nomSujet` varchar(255) DEFAULT NULL,
  `typeSujet` varchar(255) DEFAULT NULL,
  `forum_idForum` int(11) DEFAULT NULL,
  `user_idUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idSujet`),
  KEY `FKfmg6vcrltpd7363yl7amhnjar` (`forum_idForum`),
  KEY `FKpogokcnqg60rk9cj5uco6ga0x` (`user_idUser`),
  CONSTRAINT `FKfmg6vcrltpd7363yl7amhnjar` FOREIGN KEY (`forum_idForum`) REFERENCES `forum` (`idForum`),
  CONSTRAINT `FKpogokcnqg60rk9cj5uco6ga0x` FOREIGN KEY (`user_idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sujet`
--

LOCK TABLES `sujet` WRITE;
/*!40000 ALTER TABLE `sujet` DISABLE KEYS */;
/*!40000 ALTER TABLE `sujet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `competence` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `login` varchar(255) DEFAULT NULL,
  `nom` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `prenom` varchar(255) DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-04-23  2:10:34
