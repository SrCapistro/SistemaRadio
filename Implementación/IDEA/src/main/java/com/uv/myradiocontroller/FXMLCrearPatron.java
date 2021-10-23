package com.uv.myradiocontroller;

import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.stage.Stage;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

public class FXMLCrearPatron implements Initializable {
    @FXML Label labelTituloPatron;
    @FXML Button btnAñadirLinea;
    @FXML Button btnGuardarPatron;
    @FXML TableView tablaLineasPatron;
    @FXML TextField txtNombrePatron;
    @FXML ComboBox cbCategoria;
    @FXML ComboBox cbGenero;
    @FXML Button btnCancelar;

    @FXML public void botonCancelarClick(){
        try{
            Stage thisStage = (Stage) btnCancelar.getScene().getWindow();
            Stage stage = new Stage();
            Parent root = FXMLLoader.load(getClass().getResource("FXMLPatrones.fxml"));
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.setResizable(false);
            stage.setTitle("Patrones músicales");
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
