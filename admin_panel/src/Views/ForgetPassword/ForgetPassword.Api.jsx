import REQUEST from "../../Services/Request";

export const FORGET_PASSWORD=async (e) =>{

    return await REQUEST({
        url:"Auth/forget-password",
        method:"POST",
        data:e});
}