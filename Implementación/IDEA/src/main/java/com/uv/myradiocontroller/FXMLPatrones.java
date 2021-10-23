package com.uv.myradiocontroller;

import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

public class FXMLPatrones implements Initializable {

    @FXML Button btnCrearPatron;
    @FXML Button btnEliminarPatron;
    @FXML Button btnModificarPatron;
    @FXML Button btnRegresar;
    @FXML Button btnGenerarReporte;

    @FXML public void botonCrearPatronClick(){
        try{
            Stage thisStage = (Stage) btnCrearPatron.getScene().getWindow();
            Stage stage = new Stage();
            Parent root = FXMLLoader.load(getClass().getResource("FXMLCrearPatron.fxml"));
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.setResizable(false);
            stage.setTitle("Crear nuevo patrón");
            thisStage.close();
            stage.show();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @FXML public void botonCancelarClick(){
        try{
            Stage thisStage = (Stage) btnRegresar.getScene().getWindow();
            Stage stage = new Stage();
            Parent root = FXMLLoader.load(getClass().getResource("FXMLPantallaPrincipal.fxml"));
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.setResizable(false);
            stage.setTitle("My Radio Controller");
            thisStage.close();
            stage.show();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {

    }
}
