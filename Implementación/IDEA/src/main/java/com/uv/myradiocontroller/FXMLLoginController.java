/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uv.myradiocontroller;

import com.uv.DAO.DAOUsuario;
import com.uv.POJO.Usuario;
import java.io.IOException;
import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

/**
 * FXML Controller class
 *
 * @author josuecg
 */
public class FXMLLoginController implements Initializable {
    DAOUsuario daoUsuario = new DAOUsuario();
    public static Usuario usuarioIngresado = null;
    
    
    @FXML private Label lbComprobar;
    @FXML private Button btnIniciarSesion;
    @FXML private TextField tbUsuario;
    @FXML private PasswordField tbContraseña;    
    
    @FXML private void iniciarSesion(){
        if(tbUsuario.getText().isEmpty() || tbContraseña.getText().isEmpty()){
            lbComprobar.setVisible(true);
        }else{
            try {
                usuarioIngresado = daoUsuario.buscarUsuario(tbUsuario.getText(), tbContraseña.getText());
                if(usuarioIngresado != null){
                    cargarPantallaPrincipal();
                }else{
                    mostrarAlerta();
                }
            } catch (SQLException ex) {
                mostrarAlerta();
            }
        }
    }
    
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        lbComprobar.setVisible(false);
    }    
    
    public void cargarPantallaPrincipal(){
        try {
            Stage thisStage = (Stage) btnIniciarSesion.getScene().getWindow();
            Stage stage = new Stage();
            Parent root = FXMLLoader.load(getClass().getResource("FXMLPantallaPrincipal.fxml"));
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.setResizable(false);
            thisStage.close();
            stage.show();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
    
    public void mostrarAlerta(){
        Alert alert = new Alert(AlertType.ERROR);
        alert.setTitle("Inicio de sesión");
        alert.setHeaderText("Usuario no encontrado");
        alert.setContentText("Porfavor, compruebe sus datos");
        alert.showAndWait();
    }

}
