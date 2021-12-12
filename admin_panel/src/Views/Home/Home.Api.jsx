import REQUEST from "../../Services/Request";

export const STEPS = async (e, status) => {
  return await REQUEST({
    method: "get",
    url: "Steps/admin",
  });
};
