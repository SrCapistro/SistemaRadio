/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import POJO.Estacion;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author josuecg
 */
public class DAOEstacion {
    Conexion conexion = new Conexion();
    
    public ArrayList<Estacion> obtenerEstaciones() throws SQLException{
        Connection conn = conexion.getConexion();
        ArrayList<Estacion> listaEstaciones = new ArrayList<Estacion>();
        PreparedStatement stmt = conn.prepareStatement("SELECT * FROM mus_estacion");
        ResultSet rs = stmt.executeQuery();
        while(rs.next()){
             Estacion estacion = new Estacion(rs.getString("EST_NOMBRE"));
             listaEstaciones.add(estacion);
        }
        return listaEstaciones;
    }
}
