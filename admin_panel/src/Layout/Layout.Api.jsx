import REQUEST from "../Services/Request";

export const CHECK_ADMIN = async (e) => {
  return await REQUEST({
    url: "Auth/check-type",
    method: "GET",
  });
};
