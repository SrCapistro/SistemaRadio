/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package POJO;

/**
 *
 * @author josuecg
 */
public class Usuario {
    private String nombreUsuario;
    private String contraUsuario;
    private String estacionNombre;
    private String tipoUsuario;

    public Usuario(String nombreUsuario, String contraUsuario, String estacionNombre, String tipoUsuario) {
        this.nombreUsuario = nombreUsuario;
        this.contraUsuario = contraUsuario;
        this.estacionNombre = estacionNombre;
        this.tipoUsuario = tipoUsuario;
    }

    public Usuario(String nombreUsuario, String estacionNombre, String tipoUsuario) {
        this.nombreUsuario = nombreUsuario;
        this.estacionNombre = estacionNombre;
        this.tipoUsuario = tipoUsuario;
    }
    
    

    public String getNombreUsuario() {
        return nombreUsuario;
    }

    public void setNombreUsuario(String nombreUsuario) {
        this.nombreUsuario = nombreUsuario;
    }

    public String getContraUsuario() {
        return contraUsuario;
    }

    public void setContraUsuario(String contraUsuario) {
        this.contraUsuario = contraUsuario;
    }

    public String getEstacionNombre() {
        return estacionNombre;
    }

    public void setEstacionNombre(String estacionNombre) {
        this.estacionNombre = estacionNombre;
    }

    public String getTipoUsuario() {
        return tipoUsuario;
    }

    public void setTipoUsuario(String tipoUsuario) {
        this.tipoUsuario = tipoUsuario;
    }
    
    
}
