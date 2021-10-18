/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sistemaradio;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

/**
 * FXML Controller class
 *
 * @author josuecg
 */
public class FXMLPantallaPrincipalController implements Initializable {

    @FXML private Button btnMusica;
    @FXML private Button btnPatrones;
    @FXML private Button btnAgenda;
    @FXML private Button btnCerrarSesion;
    @FXML private TextField tbProgramaAlAire;
    @FXML private Button btnCronograma;
    
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        tbProgramaAlAire.setEditable(false);
    }    
    
    //Metodos de los clickListener de cada uno de los botones
    @FXML public void btnMusicaClick(){
        //Cargar respectiva ventana
    }
    
    @FXML public void btnPatronesClick(){
        //Cargar respectiva ventana
    }
    
    @FXML public void btnAgendaClick(){
        //Cargar respectiva ventana
    }
    
    @FXML public void btnCronogramaClick(){
        //Realizar respectiva funcionalidad
    }
    
    @FXML public void btnCerrarSesionClick(){
        try {
            Stage thisStage = (Stage) btnCerrarSesion.getScene().getWindow();
            Stage stage = new Stage();
            Parent root = FXMLLoader.load(getClass().getResource("FXMLLogin.fxml"));
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.setResizable(false);
            thisStage.close();
            stage.show();
        } catch (IOException ex) {
            Logger.getLogger(FXMLPantallaPrincipalController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
