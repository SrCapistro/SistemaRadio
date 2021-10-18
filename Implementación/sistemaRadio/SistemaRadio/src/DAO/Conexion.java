/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author josuecg
 */
public class Conexion {
    public static final String URL = "jdbc:mysql://sql5.freemysqlhosting.net/sql5445262";
    public static final String USUARIO = "sql5445262";
    public static final String CONTRA = "QKCdFxTjMq";
    
    public Connection getConexion(){
        Connection conn = null;
        try {
            conn = (Connection) DriverManager.getConnection(URL,USUARIO,CONTRA);
        } catch (SQLException ex) {
            Logger.getLogger(Conexion.class.getName()).log(Level.SEVERE, null, ex);
        }
        return conn;
    }
}
