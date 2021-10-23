/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uv.DAO;

import com.uv.POJO.Usuario;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author josuecg
 */
public class DAOUsuario {
    Conexion conexion = new Conexion();
    
    public Usuario buscarUsuario(String nombreUsuario, String contraUsuario) throws SQLException{
        Usuario usuarioObtenido = null;
        Connection conn = conexion.getConexion();
        PreparedStatement consulta = conn.prepareStatement("SELECT * FROM mus_usuarios WHERE USR_NOMBREUSUARIO=? AND USR_CONTRA=?");
        consulta.setString(1, nombreUsuario);
        consulta.setString(2, contraUsuario);
        ResultSet rs = consulta.executeQuery();
        while(rs.next()){
            usuarioObtenido = new Usuario(rs.getString("USR_ESTACION"),rs.getString("USR_NOMBREUSUARIO"),
                rs.getString("USR_TIPO"));
        }
        return usuarioObtenido;
    }
}
